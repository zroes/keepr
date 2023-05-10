<template>
  <div class="my-2 position-relative">
    <img class="img-fluid rounded elevation-3" :src="vault.imgUrl" alt="">

    <div class="position-absolute bottom-0 gradient rounded text-light py-3">
      <div class="d-flex justify-content-between rounded h-100 px-3 align-items-end">
        <h4 class="ff-marko">{{ vault.name }}</h4>
      </div>
      <h5 v-if="vault.isPrivate" class="text-end text-danger px-1"><i class="mdi mdi-lock"></i></h5>
    </div>
  </div>
</template>

<script>
import { computed } from "vue"
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js"
import { Vault } from "../models/Vault.js"


export default {

  props: {
    vault: { type: Vault, required: true }
  },
  setup() {
    // private variables and methods here
    return {
      // public variables and methods here
    }
  },
}
</script>

<style scoped>
img {
  height: 20vh;
  object-fit: cover;
  width: 100%;
}
</style>