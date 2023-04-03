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
        <img class="profile-picture rounded-circle" :src="profile?.picture" alt="">
        <div class="mt-3">
          <h1>{{ profile?.name }}</h1>
        </div>
        <div>
          <span>5 vaults</span> | <span>{{ keeps?.length }} keeps</span>
        </div>
      </div>
      <div class="col-lg-10">
        <h3>Vaults</h3>
      </div>
      <div class="col-lg-10">
        <h3>Keeps</h3>
        <section class="masonry">
          <KeepCard v-for="keep in keeps" :keep="keep" />
        </section>
      </div>
    </div>
  </div>
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

    onMounted(() => {
      getKeepsByProfileId();
    });

    watchEffect(() => {
      if (AppState.profile == null) {
        getProfileById()
      }
    })

    onUnmounted(() => {
      AppState.keeps = [];
      AppState.profile = null;
    });

    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard, Modal, KeepDetails }
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

