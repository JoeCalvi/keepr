<template>
    <div class="container-fluid">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-12 d-flex justify-content-center">
                <div>
                    <img class="cover-image" :src="vault?.img" alt="">
                    <div class="user-details">
                        <h1>{{ vault?.name }}</h1>
                        <span>by {{ vault?.creator.name }}</span>
                    </div>
                </div>
            </div>
            <div class="col-lg-10">
                <div class="row justify-content-center">
                    <div class="glass-card d-flex align-items-center justify-content-center">
                        <span>{{ keeps?.length }} keeps</span>
                    </div>
                </div>
                <h3>Keeps</h3>
                <section class="masonry">
                    <KeepCard v-for="keep in keeps" :keep="keep" />
                </section>
            </div>
        </div>
    </div>

    <Modal id="keep-details">
        <KeepDetails />
    </Modal>
</template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState';
import KeepCard from '../components/KeepCard.vue';
import Modal from '../components/Modal.vue';
import KeepDetails from '../components/KeepDetails.vue';

export default {
    setup() {
        const route = useRoute();
        const router = useRouter();

        async function getVaultById() {
            try {
                const vaultId = route.params.vaultId
                await vaultsService.getVaultById(vaultId)
            } catch (error) {
                logger.error(error)
                Pop.error(error)
            }
        }

        async function getKeepsInVault() {
            try {
                const vaultId = route.params.vaultId;
                await vaultsService.getKeepsInVault(vaultId);
            }
            catch (error) {
                logger.log(error);
                Pop.error(error);
                router.push({ name: "Home" });
            }
        }

        onMounted(() => {
            getVaultById();
            getKeepsInVault();
        });

        onUnmounted(() => {
            AppState.keeps = [];
            AppState.profile = null;
            AppState.activeVault = null;
        });

        return {
            vault: computed(() => AppState.activeVault),
            keeps: computed(() => AppState.keeps),
            profile: computed(() => AppState.profile),
            account: computed(() => AppState.account)
        };
    },
    components: { KeepCard, Modal, KeepDetails }
}
</script>


<style lang="scss" scoped>
$col-gap: 2vw;
$m-gap: 2vw;

.masonry {
    columns: 20vw;
    column-gap: $col-gap;
    margin-top: $m-gap;

    &>div {
        column-width: 20vw;
        display: inline-block;
    }
}

.cover-image {
    height: 50vw;
    width: 90vw;
    border-radius: 6px;
}

.glass-card {
    background: #E9D8D6;
    border-radius: 15px;
    backdrop-filter: blur(10px);
    height: 40px;
    width: 99px;
    font-family: 'Oxygen';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    line-height: 25px;
    text-align: center;
    color: #2D3436;
    transform: translateY(-30px);
}

.user-details {
    transform: translateY(-85px);
    font-family: 'Quando';
    font-style: normal;
    font-weight: 400;
    text-align: center;
    color: #FEF6F0;
    letter-spacing: 5px;
    text-transform: uppercase;
    text-shadow: 0px 6px 6px rgba(0, 0, 0, 0.45);
}
</style>