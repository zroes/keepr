<template>
  <div class="position-relative">
    <img class="img-fluid rounded elevation-3" :src="keep.imgUrl" alt="">

    <div class="position-absolute bottom-0 gradient rounded text-light py-3">
      <div class="d-flex justify-content-between rounded h-100 px-3 align-items-end">
        <h5 v-if="route.params.profileId" class="ff-marko">{{ keepNameAbbr }}</h5>
        <h4 v-else class="ff-marko">{{ keepNameAbbr }}</h4>
        <div class="" v-if="!isMobile() && !(route.params.profileId)">
          <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }" @click.stop>
            <img class="prof" :src="keep.creator.picture" :title="keep.creator.name">
          </router-link>
        </div>
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
import { useRoute } from "vue-router"
export default {
  props: { keep: { type: Keep, required: true } },
  setup(props) {
    // private variables and methods here
    const route = useRoute()
    return {
      route: route,
      isMobile() {
        return (screen.width <= 760)
      },
      keepNameAbbr: computed(() => {
        const name = props.keep.name
        let size = 15
        if (screen.width <= 760)
          size = 10
        if (name.length > size) {
          if (name[size - 1] == ' ')
            return (name.slice(0, size - 1) + '...')
          return (name.slice(0, size) + '...')

        }
        return name
      })
      // public variables and methods here
      // img: computed(() => `url(${props.keep.imgUrl})`)
    }
  },
}
</script>

<style scoped>
.prof {
  height: 5vh;
  border-radius: 40%;
}
</style>