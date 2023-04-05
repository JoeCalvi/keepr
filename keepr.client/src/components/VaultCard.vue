<template>
    <div class="VaultCard">
        <div class="card vault-card d-flex flex-column justify-content-between"
            :style="`background-image: url(${vault?.img})`">
            <div class="d-flex justify-content-end">
                <div class="d-flex justify-content-end vault-name">
                    <div v-if="vault?.creatorId == account?.id">
                        <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            <span class="edit-keep">...</span>
                        </button>
                        <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
                            <li><button class="dropdown-item" type="button">edit vault</button></li>
                            <li><button @click="deleteVault(`${vault?.id}`)" class="dropdown-item" type="button">delete
                                    vault</button></li>
                        </ul>
                    </div>
                </div>
            </div>
            <router-link :to="{ name: 'Vault', params: { vaultId: vault?.id } }">
                <div class="card-body d-flex flex-column justify-content-between">
                    <div class="vault-name">
                        {{ vault?.name }}
                        <i v-if="vault?.isPrivate" class="mdi mdi-lock-outline vault-name"></i>
                    </div>
                </div>
            </router-link>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { Vault } from '../models/Vault.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';

export default {
    props: { vault: { type: Vault, required: true } },
    setup() {
        return {
            account: computed(() => AppState.account),

            async deleteVault(vaultId) {
                try {
                    if (await Pop.confirm("Are you sure you want to delete this vault?", "This action cannot be undone.", "Delete Vault.", "warning")) {
                        await vaultsService.deleteVault(vaultId);
                    }
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.vault-card {
    width: 20vw;
    height: 15vw;
    background-position: center;
    background-size: cover;
}

.vault-name {
    font-family: 'Quando';
    font-style: normal;
    font-weight: 400;
    font-size: 2vw;
    color: #FFFFFF;
    text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.639);
    letter-spacing: 4px;
    text-transform: uppercase;
    overflow: hidden;
    text-overflow: ellipsis;
    word-wrap: normal;
    width: 15vw;
}

.create-options {
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 700;
    font-size: 16px;
    line-height: 20px;
    color: #2D2D2D;
}

.dropdown-item:hover {
    background-color: #d0c8da;
}

.edit-keep {
    color: #FFFFFF;
    text-shadow: 1px 1px 2px black;
}
</style>