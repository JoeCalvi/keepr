<template>
  <div class="container">
    <div class="row justify-content-center mt-4">
      <div class="col-lg-12 d-flex justify-content-center">
        <div>
          <img class="cover-image" :src="account?.coverImg" alt="">
        </div>
      </div>
      <div class="col-lg-12 d-flex flex-column align-items-center user-details">
        <img class="profile-picture rounded-circle" :src="account?.picture" alt="">
        <div class="mt-3">
          <h1>{{ account?.name }} <button title="Edit account details." class="btn btn-outline-dark" type="button"
              data-bs-toggle="offcanvas" data-bs-target="#edit-account" aria-controls="edit-account">
              <i class="mdi mdi-pen"></i>
            </button></h1>
        </div>
        <div>
          <span>{{ vaults?.length }} vaults</span> | <span>{{ keeps?.length }} keeps</span>
        </div>
      </div>
      <h3>Vaults</h3>
      <div class="row">
        <div v-for="vault in vaults" class="col-6 col-sm-4 mb-3">
          <VaultCard :vault="vault" />
        </div>
      </div>
      <div class="col-12">
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

  <OffCanvas id="edit-account">
    <EditAccountForm />
  </OffCanvas>
</template>

<script>
import { computed, onMounted, onUnmounted, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import KeepCard from '../components/KeepCard.vue';
import VaultCard from '../components/VaultCard.vue';
import Modal from '../components/Modal.vue';
import KeepDetails from '../components/KeepDetails.vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { accountService } from '../services/AccountService.js';
import { keepsService } from '../services/KeepsService.js';
import OffCanvas from '../components/OffCanvas.vue';
import EditAccountForm from '../components/EditAccountForm.vue';

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
      accountService.getAccount();
      getMyVaults();
      keepsService.getAllKeeps()
    })

    onUnmounted(() => {
      AppState.vaults = [];
      AppState.keeps = [];
    })

    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.myVaults),
      keeps: computed(() => AppState.keeps?.filter(k => k.creatorId == AppState.account?.id)),

    };
  },
  components: { KeepCard, Modal, KeepDetails, VaultCard, OffCanvas, EditAccountForm }
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
