<template>
  <div class="pt-3 px-3 bg-form">
    <div class="d-flex justify-content-between mx-2">
      <h3 class="form-title m-0">Edit Profile</h3>
      <i class="mdi mdi-close my-1 px-1 selectable rounded" data-bs-dismiss="modal"></i>
    </div>

    <form @submit="updateProfile()" class="p-3">
      <input class="m-1" type="text" name="" id="" placeholder="Name..." v-model="editable.name">
      <input class="m-1" type="url" name="" id="" placeholder="Profile Picture..." v-model="editable.picture">
      <input class="m-1" type="url" name="" id="" placeholder="Cover Image..." v-model="editable.coverImg">
      <div class="text-end mt-4">
        <button class="btn btn-dark">Submit</button>

      </div>
    </form>
  </div>
</template>

<script>
import { computed, ref } from "vue"
import Pop from "../utils/Pop.js"
import { Modal } from "bootstrap"
import { profilesService } from "../services/ProfilesService.js"
import { useRoute } from "vue-router"

export default {
  setup() {
    // private variables and methods here
    const editable = ref({})
    return {
      editable,
      async updateProfile() {
        try {
          await profilesService.updateProfile(editable.value)
          Modal.getOrCreateInstance('#edit-profile').hide()
          editable.value = {}
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  },
}
</script>

<style scoped>
input[type=text] {
  width: 98%;
}
</style>