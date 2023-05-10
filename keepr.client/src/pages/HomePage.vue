<template>
  <div class="container-fluid">
    <div class="row justify-content-center my-4">
      <div class="col-12 col-md-10">
        <div class="masonry-with-columns">
          <div class="mb-4" v-for="(keep, index) in keeps" @click="setActive(keep.id)">
            <KeepCard :keep="keep" class="selectable rounded" />
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
</template>

<script>
import { computed, onMounted, watchEffect } from "vue"
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js"
import { keepsService } from "../services/KeepsService.js"
import KeepCard from "../components/KeepCard.vue"
import MyModal from "../components/MyModal.vue"
import { Modal } from "bootstrap"
import KeepDetails from "../components/KeepDetails.vue"
import { profilesService } from "../services/ProfilesService.js"


export default {
  setup() {
    // private variables and methods here
    async function getAllKeeps() {
      try {
        await keepsService.getAllKeeps()
      }
      catch (error) {
        Pop.error(error)
      }
    }

    async function getMyVaults() {
      try {
        await profilesService.getVaults(AppState.account.id)
      } catch (error) {
        Pop.error(error.response.data)
      }
    }

    watchEffect(() => {
      AppState.account.id
      getMyVaults()
    })

    onMounted(() => {
      getAllKeeps()
    })
    return {
      // public variables and methods here
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.vaults),
      async setActive(keepId) {
        try {
          await keepsService.setActive(keepId)
          Modal.getOrCreateInstance('#keep-details').show()
        } catch (error) {
          Pop.error(error)
        }
      },
    }
  },
  components: { KeepCard, MyModal, KeepDetails }
}
</script>

<style>
/* .item {
  width: 100px;
  margin: 0 1rem 1rem 0;
  display: inline-block;
  width: 100%;
} */
</style>