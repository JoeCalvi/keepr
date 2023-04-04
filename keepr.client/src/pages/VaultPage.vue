<template>
    <div class="container">
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
</template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';
import { profilesService } from '../services/ProfilesService.js';
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState';
import KeepCard from '../components/KeepCard.vue';

export default {
    setup() {
        const route = useRoute();
        const router = useRouter();
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
            getKeepsInVault();
            profilesService.getProfileById(AppState.activeVault?.creatorId)
        });

        onUnmounted(() => {
            AppState.keeps = [];
            AppState.profile = null;
        });

        return {
            vault: computed(() => AppState.activeVault),
            keeps: computed(() => AppState.keeps),
            profile: computed(() => AppState.profile),
            account: computed(() => AppState.account)
        };
    },
    components: { KeepCard }
}
</script>


<style lang="scss" scoped>
$col-gap: 40px;
$m-gap: 20px;

.masonry {
    columns: 201px;
    column-gap: $col-gap;
    margin-top: $m-gap;

    &>div {
        display: inline-block;
    }
}

.cover-image {
    height: 338px;
    width: 759px;
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