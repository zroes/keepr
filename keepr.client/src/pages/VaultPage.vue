<template>
  <div class="container-fluid" v-if="vault">
    <div class="row justify-content-center mt-3">
      <div class="col-md-4 justify-content-center">
        <div class="position-relative">
          <img class="img-fluid rounded size-it" :src="vault.imgUrl" :alt="vault.name">
          <div class="position-absolute gradient rounded bottom-0 text-light text-center ff-marko text-shadow">
            <h1 class="">{{ vault.name }}</h1>
            <h5 class="">by <a :href="`/#/profile/${vault.creatorId}`">{{ vault.creator.name }}</a></h5>
            <div class="justify-content-end d-flex">
              <h4 v-if="vault.isPrivate"><i class="text-danger mdi mdi-lock"></i></h4>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row justify-content-center my-4">
      <div class="col-md-2 text-center">
        <h6 class="bg-secondary d-inline p-2 rounded-ish ff-ox">{{ keeps?.length }} Keeps</h6>
      </div>
    </div>
    <div class="row">
      <div class="col-md-8 text-center">
        <div class="d-flex justify-content-end" v-if="vault.creatorId == accountId">
          <h5 class="ff-ox user-select-none selectable rounded px-2" data-bs-toggle="dropdown">•••</h5>
          <ul class="dropdown-menu py-0">
            <li><span class="dropdown-item selectable" @click="toggleVis(vault.isPrivate, vault.id)">make {{
              vault.isPrivate ?
              'public' : 'private' }}</span>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="masonry-with-columns my-2 mb-5">
      <div class="mb-4" v-for="(keep, index) in keeps" @click="setActive(keep.id)" :key="index">
        <KeepCard :keep="keep" class="selectable rounded" />
      </div>
    </div>

    <div class="row justify-content-center my-3" v-if="accountId == vault.creatorId">
      <div class="col-2 text-center">
        <button class="btn btn-warning border-danger text-danger" @click="deleteVault()">Delete Vault</button>
      </div>
    </div>
  </div>
  <MyModal id="keep-details" size="modal-lg">
    <template #body>
      <KeepDetails :keep="activeKeep" />
    </template>
  </MyModal>
</template>

<script>
import { computed, watchEffect } from "vue"
import { AppState } from "../AppState.js"

import Pop from "../utils/Pop.js"
import { useRoute } from "vue-router"
import { vaultsService } from "../services/VaultsService.js"
import { keepsService } from "../services/KeepsService.js"
import KeepCard from "../components/KeepCard.vue"
import { router } from "../router.js"
import { Modal } from "bootstrap"
import MyModal from "../components/MyModal.vue"
export default {
  setup() {
    // private variables and methods here
    const route = useRoute()
    async function getVault() {
      try {
        await vaultsService.getVault(route.params.vaultId)
      }
      catch (error) {
        if (error.response.data == "No vault found at id " + route.params.vaultId) {
          Pop.error(error.response.data)
          router.push('/')
        }
        else
          Pop.error(error)
      }
    }
    async function getKeepsInVault() {
      try {
        await keepsService.getKeepsInVault(route.params.vaultId)
      }
      catch (error) {
        Pop.error(error)
      }
    }
    watchEffect(() => {
      route.params.vaultId
      getVault()
      getKeepsInVault()
    })
    return {
      // public variables and methods here
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep),
      accountId: computed(() => AppState.account.id),
      async setActive(keepId) {
        try {
          await keepsService.setActive(keepId)
          Modal.getOrCreateInstance('#keep-details').show()
        } catch (error) {
          Pop.error(error)
        }
      },

      async deleteVault() {
        try {
          if (await Pop.confirm("Are you sure?", "This action cannot be undone")) {
            const vaultId = this.vault.id
            await vaultsService.deleteVault(vaultId)
            router.push('/profile/' + this.vault.creatorId)
          }
        } catch (error) {

        }
      },

      async toggleVis(isPrivate, vaultId) {
        try {
          if (await Pop.confirm(`Make this vault ${isPrivate ? 'public' : 'private'}?`, "Are you sure?")) {
            await vaultsService.toggleVis(isPrivate, vaultId)
          }

        } catch (error) {
          Pop.error(error)
        }
      }
    }
  },
  components: { KeepCard, MyModal }
}
</script>

<style>
.size-it {
  height: 38vh;
  object-fit: cover;
  width: 100%;
}

.text-shadow {
  text-shadow: 0px 2px 4px black;
}

.rounded-ish {
  border-radius: 0.7em;
}
</style>