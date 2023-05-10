<template>
  <div class="container-fluid bg-det">

    <div class="row px-0" v-if="keep">
      <!-- <div class="col-6"> -->
      <img class="col-md-6 p-0 pe-md-1 img-style" :src="keep.imgUrl" alt="" data-bs-toggle="modal"
        data-bs-target="#keep-details">
      <!-- </div> -->
      <div class="col-md-6 d-flex order-it my-2 text-center px-4">
        <div class="row justify-content-center my-3">
          <div class="col-2 d-flex justify-content-center">
            <i class="mdi mdi-eye-outline"></i>
            <p class="mb-0">{{ keep.views }}</p>
          </div>
          <div class="col-2 d-flex justify-content-center">
            <i class="mdi mdi-safe"></i>
            <p class="mb-0">{{ keep.keptCount }}</p>
          </div>
        </div>

        <div class="" :class="(keep.creatorId == account.id && !route.params.vaultId) ? 'parent' : ''">
          <h3>{{ keep.name }}</h3>
          <p class="text-start">{{ keep.description }}</p>
          <div class="child my-2">
            <button :disabled="keep.creatorId != account.id || route.params.vaultId"
              class="btn border-danger text-danger btn-warning" @click="deleteKeep(keep.id)">Delete
              Keep</button>
          </div>
        </div>
        <!-- data bottom  -->
        <div class="row">
          <div class="col-7 d-flex align-items-center" v-if="!route.params.vaultId">
            <div class="d-flex" v-if="account.id">
              <select class="form-select" aria-label="select vault" v-model="selected">
                <option selected>Add to vault</option>
                <option v-for="(vault, index) in vaults" :value="vault.id">{{ vault.name }}</option>
              </select>
              <button :disabled="disabled" @click="addToVault(keep.id)" class="ms-2 btn btn-info text-light">Add</button>
            </div>
          </div>
          <div v-else class="col-7 d-flex align-items-center">
            <div v-if="account.id == activeVault?.creatorId">
              <button @click="removeFromVault(keep.vaultKeepId)" class="btn border-danger text-danger btn-warning">Remove
                from vault</button>
            </div>
          </div>
          <div class="col-5 d-flex justify-content-end" data-bs-toggle="modal" data-bs-target="#keep-details">
            <router-link class="d-flex align-items-center text-dark selectable rounded px-2 p-1"
              :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
              <img class="prof" :src="keep.creator.picture" alt="">
              <p class="m-0">{{ keep.creator.name }}</p>
            </router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from "vue"
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js"
import { Keep } from "../models/Keep.js"
import { keepsService } from "../services/KeepsService.js"
import { vaultKeepsService } from "../services/VaultKeepsService.js"

import { Modal } from "bootstrap"
import { useRoute } from "vue-router"

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    // private variables and methods here
    const selected = ref('Add to vault')
    const route = useRoute()


    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      activeVault: computed(() => AppState.activeVault),
      selected,
      route,
      disabled: computed(() => {
        return selected.value == 'Add to vault'
      }),
      async deleteKeep(keepId) {
        try {
          if (await Pop.confirm(
            "are you sure you want to delete this?", "this action is permanent")) {
            await keepsService.deleteKeep(keepId)
            Modal.getOrCreateInstance('#keep-details').hide()
          }
        } catch (error) {
          Pop.error(error)
        }
      },


      async addToVault(keepId) {
        try {
          const vkData = {}
          vkData.keepId = keepId
          vkData.vaultId = selected.value
          await vaultKeepsService.addKeepToVault(vkData)
          Modal.getOrCreateInstance('#keep-details').hide()
          Pop.toast("Successfully added", "success", "center", 1337)
        } catch (error) {
          if (error.response.data.slice(0, 15) == "Duplicate entry") {
            Pop.toast("That keep is already in that vault", "info", "bottom-end")
            selected.value = 'Add to vault'
          }
          else
            Pop.error(error)
        }
      },

      async removeFromVault(vkId) {
        try {
          if (await Pop.confirm("Are you sure you want to remove this keep from this vault?")) {
            await vaultKeepsService.removeFromVault(vkId)
            Modal.getOrCreateInstance('#keep-details').hide()
          }
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

.img-style {
  object-fit: cover;
}
</style>