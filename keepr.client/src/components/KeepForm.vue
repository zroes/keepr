<template>
  <div class="pt-3 px-3 bg-form">
    <div class="d-flex justify-content-between mx-2">
      <h3 class="form-title m-0">Add your Keep</h3>
      <i class="mdi mdi-close my-1 px-1 selectable rounded" data-bs-dismiss="modal"></i>
    </div>

    <form @submit.prevent="createKeep()" class="p-3 row">
      <div class="col-6 px-1">

        <input required class="my-1 w-100" type="text" name="" id="" placeholder="Title..." v-model="editable.name">
      </div>
      <div class="col-6 px-1">
        <input required class="my-1 w-100" type="url" name="" id="" placeholder="Image URL..." v-model="editable.img">
      </div>
      <textarea required class="mt-4 mb-2 col-12" type="text" name="" id="" placeholder="Keep Description..."
        v-model="editable.description"></textarea>
      <div class="text-end mt-4">
        <button class="btn btn-dark">Create</button>

      </div>
    </form>
  </div>
</template>

<script>
import { computed, ref } from "vue"
import Pop from "../utils/Pop.js"
import { keepsService } from "../services/KeepsService.js"
import { Modal } from "bootstrap"
import { useRoute } from "vue-router"

export default {
  setup() {
    const route = useRoute()
    // private variables and methods here
    const editable = ref({})
    return {
      editable,
      async createKeep() {
        try {
          await keepsService.createKeep(editable.value, route.params.profileId, route.params.vaultId)
          Modal.getOrCreateInstance('#create-keep').hide()
          Pop.toast("Creation successful", "success", "center", 1337)
          editable.value = {}
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  },
}
</script>

<style>
input,
textarea {
  background-color: #f9f6fa;
  border: none;
  border-bottom: 1.5px solid #7a8186;
  border-radius: 1.2px;
}

input {
  width: 48%;
}

textarea {
  width: 100%;
  height: 130px;
}

input:focus,
textarea:focus {
  outline: 1px solid #7a8186;
}

.bg-form {
  background-color: #f9f6fa;
}

.form-title {
  color: #636e72;
}
</style>