<template>
    <div class="modal-content modal-keep-details">
        <div class="container-fluid">
            <div class="row d-flex align-items-center">
                <div class="col-lg-6 keep-image" :style="`background-image: url(${keep?.img})`"></div>
                <div class="col-lg-6 keep-info d-flex flex-column justify-content-between">
                    <div class="row justify-content-center mt-4">
                        <div class="col-lg-6 d-flex justify-content-end">
                            <span class="d-flex gap-2 align-items-center"><i
                                    class="mdi mdi-eye-outline eye-size"></i><span>{{ keep?.views
                                    }}</span></span>
                        </div>
                        <div class="col-lg-6 d-flex justify-content-start">
                            <span class="d-flex gap-2 align-items-center"><img src="../assets/img/public/Logo (1).png"
                                    alt=""><span>{{ keep?.kept }}</span></span>
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
                    <div class="row mb-4">
                        <div class="col-lg-6 d-flex justify-content-end gap-2">
                            <div class="dropdown">
                                <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown"
                                    aria-expanded="false">
                                    <span class="vault-name">vault</span>
                                </button>
                                <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
                                    <li><button class="dropdown-item" type="button">vault 1</button></li>
                                    <li><button class="dropdown-item" type="button">vault 2</button></li>
                                </ul>
                            </div>
                            <button class="btn save-button">save</button>
                        </div>
                        <div class="col-lg-6 d-flex align-items-center gap-2">
                            <div>
                                <img class="creator-picture rounded-circle img-fluid" :src="keep?.creator.picture" alt="">
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
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
export default {
    setup() {
        return {
            keep: computed(() => AppState.activeKeep)
        }
    }
}
</script>


<style lang="scss" scoped>
.keep-image {
    width: 549px;
    height: 657px;
    border-radius: 21px 0px 0px 21px;
    background-size: cover;
    background-position: center;
}

.keep-info {
    width: 549px;
    height: 657px;
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
    width: 1100px;
    height: 657px;
}

.eye-size {
    font-weight: 400;
    font-size: 24px;
    color: #636E72;
}
</style>