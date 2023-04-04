<template>
  <div class="container">
    <div class="row justify-content-center mt-5">
      <div class="col-lg-12 d-flex justify-content-center">
        <div>
          <img class="cover-image"
            src="https://i.etsystatic.com/26950383/r/il/d906d6/4272278909/il_1080xN.4272278909_3hrr.jpg" alt="">
        </div>
      </div>
      <div class="col-lg-12 d-flex flex-column align-items-center user-details">
        <img class="profile-picture rounded-circle" :src="account?.picture" alt="">
        <div class="mt-3">
          <h1>{{ account?.name }}</h1>
        </div>
        <div>
          <span>{{ vaults?.length }} vaults</span> | <span>{{ keeps?.length }} keeps</span>
        </div>
      </div>
      <div class="col-lg-10">
        <h3>Vaults</h3>
        <div class="row">
          <div v-for="vault in vaults" class="col-lg-3 col-md-4 col-sm-6 my-2">
            <router-link :to="{ name: 'Vault', params: { vaultId: vault?.id } }">
              <VaultCard :vault="vault" />
            </router-link>
          </div>
        </div>
      </div>
      <div class="col-lg-10">
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
import { computed, onMounted, onUnmounted } from 'vue'
import { AppState } from '../AppState.js'
import KeepCard from '../components/KeepCard.vue';
import VaultCard from '../components/VaultCard.vue';
import Modal from '../components/Modal.vue';
import KeepDetails from '../components/KeepDetails.vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { accountService } from '../services/AccountService.js';
import { keepsService } from '../services/KeepsService.js';

export default {
  setup() {

    async function getMyVaults() {
      try {
        await accountService.getMyVaults();
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    onMounted(() => {
      getMyVaults();
      keepsService.getAllKeeps()
    })

    onUnmounted(() => {
      AppState.vaults = [];
      AppState.keeps = [];
    })

    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps?.filter(k => k.creatorId == AppState.account?.id))
    };
  },
  components: { KeepCard, Modal, KeepDetails, VaultCard }
}
</script>

<style scoped lang="scss">
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

.profile-picture {
  height: 150px;
  width: 150px;
}

.user-details {
  transform: translateY(-75px);
  font-family: 'Oxygen';
  font-style: normal;
  font-weight: 400;
  font-size: 20px;
  line-height: 25px;
  text-align: center;
  color: #000000;
}
</style>
