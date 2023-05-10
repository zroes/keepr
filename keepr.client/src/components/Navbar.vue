<template>
  <nav class="d-flex my-1 justify-content-between px-3 elevation-c">
    <div class="d-flex align-items-center">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">

        <h4 class="selectable ff-ox mb-0 text-dark bg-primary px-3 fw-bold p-1 rounded-pill">Home</h4>

      </router-link>
      <div class="dropdown user-select-none" :class="account.id == undefined ? 'disabled hide' : ''">
        <h4 class="dropdown-toggle selectable ff-ox mb-0 text-dark rounded-pill p-1 px-3" type="button"
          id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
          Create <i class="mdi mdi-menu-down"></i>
        </h4>
        <ul class="dropdown-menu py-0" aria-labelledby="dropdownMenuButton1">
          <li data-bs-toggle="modal" data-bs-target="#create-keep"><span class="dropdown-item rounded">new keep</span>
          </li>
          <li data-bs-toggle="modal" data-bs-target="#create-vault"><span class="dropdown-item rounded">new vault</span>
          </li>
        </ul>
      </div>
    </div>

    <div class="justify-content-center">
      <img class="mb-3" src="../assets/img/Keepr logo.png" alt="">
    </div>
    <!-- LOGIN COMPONENT HERE -->

    <div class="ms-md-5">
      <div class="ms-md-5">
        <div class="ms-md-5">
          <div class="my-3 ms-md-5">
            <Login />
          </div>
        </div>
      </div>
    </div>
  </nav>
  <!-- <div class="border-top border-light border-5"></div> -->
  <MyModal id="create-keep">
    <template #body>
      <KeepForm />
    </template>
  </MyModal>
  <MyModal id="create-vault">
    <template #body>
      <VaultForm />
    </template>
  </MyModal>
</template>

<script>
import { computed } from "vue"
import Login from './Login.vue'
import MyModal from "./MyModal.vue"
import VaultForm from "./VaultForm.vue"
import { AppState } from "../AppState.js"

export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  },
  components: { Login, MyModal, VaultForm }
}
</script>

<style scoped>
.elevation-c {
  box-shadow: 0px 2px 4px #2d2d2d1b, 0px 2px 0px #f9f6fa;
}

.hide {
  opacity: 0;
}

.disabled::after {
  cursor: default !important;
}
</style>
