<template>
    <div class="VaultCard">
        <div class="card vault-card" :style="`background-image: url(${vault?.img})`">
            <div class="card-body d-flex flex-column justify-content-between">
                <div class="text-end vault-name">
                    <i v-if="vault?.isPrivate" class="mdi mdi-lock-outline vault-name"></i>
                </div>
                <div class="vault-name">
                    {{ vault?.name }}
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { Vault } from '../models/Vault.js';

export default {
    props: { vault: { type: Vault, required: true } },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
.vault-card {
    width: 195px;
    height: 135px;
    background-position: center;
    background-size: cover;
}

.vault-name {
    font-family: 'Quando';
    font-style: normal;
    font-weight: 400;
    font-size: 24px;
    line-height: 30px;
    color: #FFFFFF;
    text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.639);
    letter-spacing: 4px;
    text-transform: uppercase;
    overflow: hidden;
    text-overflow: ellipsis;
    word-wrap: normal;
    width: 170px;
}
</style>