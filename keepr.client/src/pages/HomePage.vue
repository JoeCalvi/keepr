<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-md-12">
        <section class="masonry">
          <div v-for="keep in keeps">
            <KeepCard :keep="keep" title="See Keep Details" />
          </div>
        </section>
      </div>
    </div>
  </div>

  <Modal id="keep-details">
    <KeepDetails />
  </Modal>
</template>

<script>
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { keepsService } from "../services/KeepsService.js";
import { computed, onMounted, onUnmounted, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import Modal from '../components/Modal.vue';
import KeepDetails from '../components/KeepDetails.vue';
import { accountService } from '../services/AccountService.js';

export default {
  setup() {
    async function getAllKeeps() {
      try {
        await keepsService.getAllKeeps();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }

    onMounted(() => {
      getAllKeeps();

    });

    watchEffect(() => {
      if (AppState.account?.id) {
        accountService.getMyVaults()
      }
    })

    onUnmounted(() => {
      AppState.keeps = [];
    });

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard, Modal, KeepDetails }
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
</style>
