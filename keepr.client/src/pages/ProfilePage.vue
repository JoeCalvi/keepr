<template>
  <div class="container-fluid">
    <div class="row justify-content-center mt-5">
      <div class="col-lg-12 d-flex justify-content-center">
        <div>
          <img class="cover-image"
            src="https://i.etsystatic.com/26950383/r/il/d906d6/4272278909/il_1080xN.4272278909_3hrr.jpg" alt="">
        </div>
      </div>
      <div class="col-lg-12 d-flex flex-column align-items-center user-details">
        <img class="profile-picture rounded-circle" :src="profile?.picture" alt="">
        <div class="mt-3">
          <h1>{{ profile?.name }}</h1>
        </div>
        <div>
          <span>{{ vaults?.length }} vaults</span> | <span>{{ keeps?.length }} keeps</span>
        </div>
      </div>
      <h3>Vaults</h3>
      <div class="row">
        <div v-for="vault in vaults" class="col-sm-3 my-2">
          <router-link :to="{ name: 'Vault', params: { vaultId: vault?.id } }">
            <VaultCard :vault="vault" title="Go To Vault" />
          </router-link>
        </div>
      </div>
      <div class="col-12">
        <h3>Keeps</h3>
        <div class="row">
          <col-12>
            <section class="masonry">
              <KeepCard v-for="keep in keeps" :keep="keep" title="See Keep Details" />
            </section>
          </col-12>
        </div>
      </div>
    </div>
  </div>

  <Modal id="keep-details">
    <KeepDetails />
  </Modal>
</template>

<script>
import { computed, onMounted, watchEffect, onUnmounted } from 'vue'
import { AppState } from '../AppState.js'
import KeepCard from '../components/KeepCard.vue';
import Modal from '../components/Modal.vue';
import KeepDetails from '../components/KeepDetails.vue';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js';
import { profilesService } from "../services/ProfilesService.js";
import { vaultsService } from '../services/VaultsService.js';
import VaultCard from '../components/VaultCard.vue';

export default {
  setup() {
    const route = useRoute()

    async function getProfileById() {
      try {
        const profileId = route.params.profileId
        await profilesService.getProfileById(profileId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    async function getKeepsByProfileId() {
      try {
        const profileId = route.params.profileId
        await keepsService.getKeepsByProfileId(profileId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    async function getVaultsByProfileId() {
      try {
        const profileId = route.params.profileId
        await vaultsService.getVaultsByProfileId(profileId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    onMounted(() => {
      getKeepsByProfileId();
      getVaultsByProfileId();
    });

    watchEffect(() => {
      if (AppState.profile == null) {
        getProfileById();
        getVaultsByProfileId();
        getKeepsByProfileId();
      }
    })

    onUnmounted(() => {
      AppState.keeps = [];
      AppState.vaults = [];
      AppState.profile = null;
    });

    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    };
  },
  components: { KeepCard, Modal, KeepDetails, VaultCard }
}
</script>

<style scoped lang="scss">
$col-gap: 2vw;
$m-gap: 2vw;

.masonry {
  columns: 30vw;
  column-gap: $col-gap;
  margin-top: $m-gap;

  &>div {
    column-width: 30vw;
    display: inline-block;
  }
}

.cover-image {
  height: 50vw;
  width: 90vw;
  border-radius: 6px;
}

.profile-picture {
  height: 15vw;
  width: 15vw;
  display: flex;
}

.user-details {
  transform: translateY(-7vw);
  font-family: 'Oxygen';
  font-style: normal;
  font-weight: 400;
  font-size: 20px;
  line-height: 25px;
  text-align: center;
  color: #000000;
}
</style>

