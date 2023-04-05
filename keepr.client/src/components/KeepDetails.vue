<template>
    <div class="modal-dialog modal-xl">
        <div class="modal-content modal-keep-details">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12 d-flex flex-column justify-content-between d-lg-none keep-image-m"
                        :style="`background-image: url(${keep?.img})`">
                        <div class="row justify-content-center align-items-center mt-4 counts-m">
                            <div class="col-6 d-flex justify-content-end">
                                <span class="d-flex gap-2 align-items-center"><i class="mdi mdi-eye-outline"></i><span>{{
                                    keep?.views
                                }}</span></span>
                            </div>
                            <div class="col-6 d-flex justify-content-start">
                                <span class="d-flex gap-2 align-items-center"><i
                                        class="mdi mdi-alpha-k-box-outline"></i><span>{{ keep?.kept }}</span></span>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="d-flex justify-content-evenly">
                                <div class="dropdown">
                                    <button class="btn dropdown-toggle vault-name-m" type="button" data-bs-toggle="dropdown"
                                        aria-expanded="false">
                                        <span class="">vault</span>
                                    </button>
                                    <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
                                        <div v-for="vault in vaults">
                                            <li><button class="dropdown-item" type="button"
                                                    @click="setSelectedVault(`${vault?.id}`)">{{
                                                        vault?.name }}</button></li>
                                        </div>
                                    </ul>
                                </div>
                                <button class="btn save-button-m" @click="createVaultKeep(`${keep?.id}`)">save</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row align-items-center d-none d-lg-flex">
                    <div class="col-lg-6 keep-image" :style="`background-image: url(${keep?.img})`"></div>
                    <div class="col-lg-6 keep-info d-flex flex-column justify-content-between">
                        <div class="row justify-content-center align-items-center mt-4">
                            <div class="col-6 d-flex justify-content-end">
                                <span class="d-flex gap-2 align-items-center"><i
                                        class="mdi mdi-eye-outline eye-size"></i><span>{{ keep?.views
                                        }}</span></span>
                            </div>
                            <div class="col-6 d-flex justify-content-start">
                                <span class="d-flex gap-2 align-items-center"><i
                                        class="mdi mdi-alpha-k-box-outline eye-size"></i><span>{{ keep?.kept
                                        }}</span></span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div>
                                    <h1 class="keep-name">{{ keep?.name }}</h1>
                                    <p class="keep-description">
                                        {{ keep?.description }}
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-4 flex-xl-row flex-xs-column">
                            <div
                                class="col-xl-6 order-xl-1 order-xs-2 d-flex align-items-center justify-content-xl-end justify-content-sm-center gap-2 mb-3">
                                <div class="dropdown">
                                    <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown"
                                        aria-expanded="false">
                                        <span class="vault-name">vault</span>
                                    </button>
                                    <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
                                        <div v-for="vault in vaults">
                                            <li><button class="dropdown-item" type="button"
                                                    @click="setSelectedVault(`${vault?.id}`)">{{
                                                        vault?.name }}</button></li>
                                        </div>
                                    </ul>
                                </div>
                                <button class="btn save-button" @click="createVaultKeep(`${keep?.id}`)">save</button>
                            </div>
                            <div
                                class="d-none d-sm-flex col-xl-6 order-xl-2 order-xs-1 align-items-center justify-content-xl-start justify-content-sm-center gap-2 mb-3">
                                <div>
                                    <img class="creator-picture rounded-circle img-fluid" :src="keep?.creator.picture"
                                        alt="">
                                </div>
                                <div class="creator-name">
                                    <span>{{ keep?.creator.name }}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { vaultKeepsService } from "../services/VaultKeepsService";

export default {
    setup() {
        return {
            keep: computed(() => AppState.activeKeep),
            vaults: computed(() => AppState.myVaults),

            setSelectedVault(vaultId) {
                AppState.selectedVault = AppState.myVaults.find(v => v.id == vaultId)
                logger.log(AppState.selectedVault)
            },

            async createVaultKeep(keepId) {
                try {
                    const vaultId = AppState.selectedVault.id
                    await vaultKeepsService.createVaultKeep(vaultId, keepId)
                    AppState.selectedVault = null
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
.keep-image {
    width: 50%;
    height: 41.0625em;
    border-radius: 21px 0px 0px 21px;
    background-size: cover;
    background-position: center;
}

.keep-image-m {
    width: 100%;
    height: 41.0625em;
    border-radius: 21px 21px 21px 21px;
    background-size: cover;
    background-position: center;
}

.keep-info {
    width: 50%;
    height: 41.0625em;
    border-radius: 0px 21px 21px 0px;
    background-color: #FEF6F0;
}

.keep-name {
    font-family: 'Marko One';
    font-style: normal;
    font-weight: 400;
    font-size: 48px;
    line-height: 64px;
    text-align: center;
    color: #2D3436;
}

.keep-description {
    font-family: 'Inter';
    font-style: normal;
    font-weight: 400;
    font-size: 18px;
    line-height: 175%;
    color: #636E72;
}

.create-options {
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 700;
    font-size: 24px;
    line-height: 30px;
    color: #2D2D2D;
}

.dropdown-item:hover {
    background-color: #d0c8da;
}

.vault-name {
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    line-height: 25px;
    color: #2D2D2D;
    letter-spacing: 10px;
    text-transform: uppercase;
}

.vault-name-m {
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    line-height: 25px;
    color: #ffffff;
    text-shadow: 1px 2px 2px black;
    letter-spacing: 10px;
    text-transform: uppercase;
}

.counts-m {
    color: #ffffff;
    font-weight: 400;
    font-size: 24px;
    text-shadow: 1px 2px 2px black;
}

.save-button {
    background-color: #877A8F;
    border-radius: 10px;
    color: #FEF6F0;
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 500;
    font-size: 20px;
    line-height: 25px;
    display: flex;
    align-items: center;
    text-align: center;
    box-shadow: 0px 4px 4px rgba(162, 119, 217, 0.25);
}

.save-button-m {
    background-color: #877A8F;
    border-radius: 10px;
    color: #FEF6F0;
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 500;
    font-size: 20px;
    line-height: 25px;
    display: flex;
    align-items: center;
    text-align: center;
    border: 1px solid white;
    box-shadow: 0px 4px 4px rgba(162, 119, 217, 0.25);
}

.save-button:hover {
    background-color: #6f6477;
    color: #f8f3ee;
    box-shadow: 2px 6px 6px rgba(162, 119, 217, 0.25);
}

.creator-picture {
    width: 40px;
    height: 40px;
    filter: drop-shadow(0px 4.79889px 4.79889px rgba(0, 0, 0, 0.25));
}

.creator-name {
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 700;
    font-size: 18px;
    line-height: 23px;
    color: #000000;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
    width: 10em;
}

.modal-keep-details {
    border-radius: 21px 21px 21px 21px;
}

.eye-size {
    font-weight: 400;
    font-size: 24px;
    color: #636E72;
}
</style>