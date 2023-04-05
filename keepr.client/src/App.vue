<template>
  <header class="sticky-top d-none d-sm-block">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="sticky-bottom d-block d-sm-none">
    <Navbar />
  </footer>

  <Modal id="add-keep">
    <AddKeepForm />
  </Modal>

  <Modal id="add-vault">
    <AddVaultForm />
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Modal from "./components/Modal.vue";
import AddKeepForm from "./components/AddKeepForm.vue";
import AddVaultForm from './components/AddVaultForm.vue';

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Modal, AddKeepForm, AddVaultForm }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

main {
  background-color: #FEF6F0;
  ;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
  background-color: #FEF6F0;
}
</style>
