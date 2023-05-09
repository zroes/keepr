<template>
  <header>
    <Navbar />
  </header>
  <main class="">
    <router-view />
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.masonry-with-columns {
  columns: 150px 4;
  column-gap: 1em;
}

.gradient {
  background: linear-gradient(to bottom, rgba(0, 0, 0, 0) 10%, rgba(0, 0, 0, 0.885));

  height: 11vh;
  /* width: 91.6%; */
  width: 100%;
}

.ff-marko {
  font-family: 'Marko One';
  font-style: normal;
  font-weight: 400;
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
