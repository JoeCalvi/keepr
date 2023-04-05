<template>
    <div class="KeepCard">
        <img @click="setActiveKeep(`${keep?.id}`)" class="img-fluid keep selectable" :src="keep?.img" :alt="keep?.img"
            data-bs-toggle="modal" data-bs-target="#keep-details">
        <div class="keep-info d-flex justify-content-between align-items-center px-2">
            <span class="keep-name">
                {{ keep?.name }}
            </span>
            <router-link :to="{ name: 'Profile', params: { profileId: keep?.creatorId } }">
                <img v-if="keep?.creatorId != account?.id && activeVault?.id == null" class="creator-picture rounded-circle"
                    :src="keep?.creator.picture" :alt="keep?.creator.picture">
            </router-link>
            <div v-if="keep?.creatorId == account?.id && !activeVault || activeVault && activeVault?.creatorId == account?.id"
                class="dropstart">
                <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <span class="edit-keep">...</span>
                </button>
                <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
                    <li v-if="activeVault?.id == null && keep?.creatorId == account?.id"><button class="dropdown-item"
                            type="button">edit keep</button></li>
                    <li v-if="activeVault?.id && activeVault?.creatorId == account?.id"><button
                            @click="removeFromVault(`${keep?.vaultKeepId}`)" class="dropdown-item" type="button">remove from
                            vault</button></li>
                    <li v-if="keep?.creatorId == account?.id"><button @click="deleteKeep(`${keep?.id}`)"
                            class="dropdown-item" type="button">delete
                            keep</button></li>
                </ul>
            </div>
        </div>
    </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState';
import { Keep } from '../models/Keep.js';
import { keepsService } from '../services/KeepsService';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultKeepsService } from '../services/VaultKeepsService';
import { vaultsService } from '../services/VaultsService';

export default {
    props: { keep: { type: Keep, required: true } },
    setup(props) {
        return {
            account: computed(() => AppState.account),
            activeVault: computed(() => AppState.activeVault),

            async setActiveKeep(keepId) {
                try {
                    AppState.activeKeep = null
                    await keepsService.setActiveKeep(keepId)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },

            async removeFromVault(vaultKeepId) {
                try {
                    if (await Pop.confirm("Are you sure you want to remove this keep from this vault?", "You will have to find keep if you wish to re-add it.", "Remove keep.", "warning")) {
                        await vaultKeepsService.removeFromVault(vaultKeepId)
                    }
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },

            async deleteKeep(keepId) {
                try {
                    if (await Pop.confirm("Are you sure you want to delete this keep?", "This action cannot be undone.", "Delete Keep.", "warning")) {
                        await vaultsService.deleteKeep(keepId)
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
.keep {
    border-radius: 6.95px;
    filter: drop-shadow(0px 5.55897px 5.55897px rgba(0, 0, 0, 0.25));
}

.keep-info {
    font-family: 'Marko One';
    font-style: normal;
    font-weight: 400;
    font-size: 24px;
    line-height: 32px;
    color: #FFFFFF;
    text-shadow: 1px 1px 2px #2D2D2D;
    transform: translateY(-48px);
}

.keep-name {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    max-width: 140px;
}

.creator-picture {
    height: 40px;
    width: 40px;
    filter: drop-shadow(0px 4.79889px 4.79889px rgba(0, 0, 0, 0.25));
}

img:hover {
    box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.25);
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
}
</style>