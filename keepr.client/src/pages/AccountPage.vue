<template></template>

<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState'
import { router } from "../router.js"
import { logger } from "../utils/Logger.js"
export default {
  setup() {
    watchEffect(() => {
      if (AppState.account.id)
        router.push({ name: 'Profile', params: { profileId: AppState.account.id } })
    })
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
