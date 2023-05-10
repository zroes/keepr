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

        <div class="" :class="keep.creatorId == account.id ? 'parent' : ''">
          <h3>{{ keep.name }}</h3>
          <p class="text-start">{{ keep.description }}</p>
          <div class="child my-2">
            <button :disabled="keep.creatorId != account.id" class="btn border-danger text-danger selectable"
              @click="deleteKeep(keep.id)">Delete
              Keep</button>
          </div>
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
import { keepsService } from "../services/KeepsService.js"
import { Modal } from "bootstrap"
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    // private variables and methods here
    return {
      account: computed(() => AppState.account),

      async deleteKeep(keepId) {
        try {
          if (await Pop.confirm("are you sure you want to delete this?", "this action is permanent"))
            await keepsService.deleteKeep(keepId)

          Modal.getOrCreateInstance('#keep-details').hide()
        } catch (error) {
          Pop.error(error)
        }
      }
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

.child {
  opacity: 0;
  transition: all 0.2s ease-in-out;
  /* background-color: #dc3545;
  color: #f7f5f5; */
}

.parent:hover .child {
  opacity: 100;
}
</style>