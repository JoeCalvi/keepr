<template>
  <nav class="navbar align-items-center justify-content-between px-3">
    <div class="d-flex align-items-center gap-2 mb-3">
      <router-link :to="{ name: 'Home' }">
        <div class="glass-card d-none d-sm-flex align-items-center justify-content-center selectable p-2">Home</div>
      </router-link>
      <div class="dropdown d-none d-sm-block">
        <button class="btn dropdown-style dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
          <li><button class="dropdown-item" style="border-bottom: 1px solid #2D3436;" type="button" data-bs-toggle="modal"
              data-bs-target="#add-keep">new keep</button></li>
          <li><button class="dropdown-item" type="button" data-bs-toggle="modal" data-bs-target="#add-vault">new
              vault</button></li>
        </ul>
      </div>
      <div class="dropup d-sm-none d-block">
        <button class="btn dropdown-style dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
          <li><button class="dropdown-item" style="border-bottom: 1px solid #2D3436;" type="button" data-bs-toggle="modal"
              data-bs-target="#add-keep">new keep</button></li>
          <li><button class="dropdown-item" type="button" data-bs-toggle="modal" data-bs-target="#add-vault">new
              vault</button></li>
        </ul>
      </div>
    </div>
    <div class="mb-3">
      <router-link :to="{ name: 'Home' }">
        <img class="logo" src="../assets/img/public/Keepr logo.png" alt="">
      </router-link>
    </div>
    <div class="mb-3">
      <Login />
    </div>
  </nav>
</template>

<script>

import Login from './Login.vue'

export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
.navbar {
  background-color: #FEF6F0;
  color: #2D2D2D;
  height: 90px;
  font-family: Oxygen;
  font-weight: bold;
  font-size: 23px;
  filter: drop-shadow(0px 0px 9px rgba(0, 0, 0, 0.25));
}

.create-options {
  font-family: 'Oxygen';
  font-style: normal;
  font-weight: 700;
  font-size: 24px;
  line-height: 30px;
  color: #2D3436;
}

.dropdown-item:hover {
  background-color: #d0c8da;
}

.dropdown-style {
  background-color: #FEF6F0;
  font-family: Oxygen;
  font-weight: bold;
  font-size: 23px;
}

.logo {
  transform: translateX(-5vw);
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}

.glass-card {
  background: #E9D8D6;
  border-radius: 15px;
  backdrop-filter: blur(10px);
  color: #2D2D2D;
}
</style>
