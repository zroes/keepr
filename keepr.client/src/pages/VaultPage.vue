<template>
  <div class="" v-if="vault">
    <h1>{{ vault.name }}</h1>
  </div>
</template>

<script>
import { computed, onMounted } from "vue"
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js"
import { useRoute } from "vue-router"
import { vaultsService } from "../services/VaultsService.js"
export default {
  setup() {
    // private variables and methods here
    const route = useRoute()

    async function getVault() {
      try {
        await vaultsService.getVault(route.params.vaultId)
      } catch (error) {
        Pop.error(error)
      }
    }
    onMounted(() => {
      getVault()
    })
    return {
      // public variables and methods here
      vault: computed(() => AppState.activeVault)
    }
  },
}
</script>

<style></style>