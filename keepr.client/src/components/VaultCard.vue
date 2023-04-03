<template>
    <div class="VaultCard">
        <div class="card vault-card" :style="`background-image: url(${vault?.img})`">
            <div class="card-body d-flex flex-column justify-content-end">
                <span class="vault-name">{{ vault?.name }}</span>
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
    height: 131px;
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
    text-shadow: 1px 1px 4px rgba(0, 0, 0, 0.25);
    letter-spacing: 4px;
    text-transform: uppercase;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
    width: 170px;
}
</style>