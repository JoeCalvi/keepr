<template>
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-lg-10">
        <section class="masonry">
          <div v-for="keep in keeps">
            <KeepCard :keep="keep" />
          </div>
        </section>
      </div>
    </div>
  </div>
</template>

<script>
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { keepsService } from "../services/KeepsService.js";
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';

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
    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard }
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
</style>
