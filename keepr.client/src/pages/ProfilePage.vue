<template>
  <div class="container-fluid my-3" v-if="profile">
    <div class="row justify-content-center">
      <div class="col-md-7 text-center">
        <div class="position-relative mb-3">
          <img :src="profile.coverImg" class="img-fluid rounded" alt="">
          <div class="position-absolute move">
            <img :src="profile.picture" alt="" class="rounded prof">
          </div>
        </div>
        <div class="d-flex justify-content-end" v-if="route.params.profileId == accountId">
          <h5 class="ff-ox user-select-none selectable rounded px-2" data-bs-toggle="dropdown">•••</h5>
          <ul class="dropdown-menu py-0">
            <li><span class="dropdown-item selectable" data-bs-toggle="modal" data-bs-target="#edit-profile">edit</span>
            </li>
          </ul>
        </div>
        <div v-else class="hidden">
          <p>•</p>
        </div>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-md-5 text-center my-3">
        <h1>{{ profile.name }}</h1>
        <div class="d-flex justify-content-evenly">
          <h5>{{ vaults.length }} vaults | {{ keeps.length }} keeps</h5>
        </div>


      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-md-8">

        <h2>Vaults:</h2>
        <div class="row">
          <div class="col-md-4 px-md-2" v-for="vault in vaults">
            <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }">
              <VaultCard :vault="vault" />
            </router-link>
          </div>
        </div>
        <h2>Keeps:</h2>
        <div class="masonry-with-columns my-2">
          <div class="mb-4" v-for="(keep, index) in keeps" @click="setActive(keep.id)">
            <KeepCard :keep="keep" class="selectable" />
          </div>
        </div>
      </div>
    </div>
  </div>
  <MyModal id="keep-details" size="modal-lg">
    <template #body>
      <KeepDetails :keep="activeKeep" />
    </template>
  </MyModal>

  <MyModal id="edit-profile">
    <template #body>
      <ProfileForm />
    </template>
  </MyModal>
</template>

<script>
import { computed, onMounted, watchEffect } from "vue"
import { AppState } from "../AppState.js"
import Pop from "../utils/Pop.js"
import { useRoute } from "vue-router"
import { profilesService } from "../services/ProfilesService.js"
import { keepsService } from "../services/KeepsService.js"

import KeepCard from "../components/KeepCard.vue"
import MyModal from "../components/MyModal.vue"
import KeepDetails from "../components/KeepDetails.vue"
import { Modal } from "bootstrap"
import VaultCard from "../components/VaultCard.vue"
import ProfileForm from "../components/ProfileForm.vue"

export default {
  setup() {
    // private variables and methods here
    const route = useRoute()
    async function getProfile() {
      try {
        await profilesService.getProfile(route.params.profileId)
      }
      catch (error) {
        Pop.error(error)
      }
    }
    async function getProfileKeeps() {
      try {
        await profilesService.getKeeps(route.params.profileId)
      }
      catch (error) {
        Pop.error(error)
      }
    }
    async function getProfileVaults() {
      try {
        await profilesService.getVaults(route.params.profileId)
      }
      catch (error) {
        Pop.error(error)
      }
    }
    // logger.log(route.params.profileId)
    watchEffect(() => {
      route.params.profileId
      getProfile()
      getProfileKeeps()
      getProfileVaults()
    })
    return {
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      activeKeep: computed(() => AppState.activeKeep),
      route: route,
      accountId: computed(() => AppState.account.id),

      async setActive(keepId) {
        try {
          await keepsService.setActive(keepId)
          Modal.getOrCreateInstance('#keep-details').show()
        } catch (error) {
          Pop.error(error)
        }
      },
      // public variables and methods here
    }
  },
  components: { KeepCard, MyModal, KeepDetails, VaultCard, ProfileForm }
}
</script>

<style scoped>
.move {
  /* bottom: -50px; */
  left: 50%;
  transform: translate(-50%, -50%);
}

.prof {
  height: 10vh;
}
</style>