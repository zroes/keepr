<template>
  <div class="container-fluid ff-ox bg-det">

    <div class="row px-0" v-if="keep">
      <!-- <div class="col-6"> -->
      <img class="col-6" :src="keep.imgUrl" alt="">
      <!-- </div> -->
      <div class="col-6 d-flex order-it my-2 text-center px-4">
        <div class="row justify-content-center">
          <div class="col-2 d-flex justify-content-center">
            <i class="mdi mdi-eye-outline"></i>
            <p>{{ keep.views }}</p>
          </div>
          <div class="col-2 d-flex justify-content-center">
            <i class="mdi mdi-safe"></i>
            <p>{{ keep.keptCount }}</p>
          </div>
        </div>
        <div class="">
          <h3>{{ keep.name }}</h3>
          <p class="text-start">{{ keep.description }}</p>
        </div>
        <p>data bottom</p>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "vue"
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js"
import { Keep } from "../models/Keep.js"
export default {
  props: {
    keep: { type: Keep, required: true }
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
.row>* {
  padding-left: 0;
}

.order-it {
  flex-direction: column;
  justify-content: space-between;
}

.bg-det {
  background-color: #fef6f0;
}
</style>