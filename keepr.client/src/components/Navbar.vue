<template>
  <nav class="navbar d-flex align-items-center justify-content-between px-3">
    <div class="d-flex align-items-center gap-2">
      <router-link :to="{ name: 'Home' }">
        <div class="glass-card d-flex align-items-center justify-content-center selectable">Home</div>
      </router-link>
      <div class="dropdown">
        <button class="btn dropdown-style dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu create-options" style="background-color: #DED6E9;">
          <li><button class="dropdown-item" style="border-bottom: 1px solid #2D3436;" type="button">new keep</button></li>
          <li><button class="dropdown-item" type="button">new vault</button></li>
        </ul>
      </div>
    </div>
    <div>
      <img class="logo" src="../public/img/Keepr logo.png" alt="">
    </div>
    <Login />
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
  transform: translateX(-75px);
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
  height: 39px;
  width: 99px;
}
</style>
