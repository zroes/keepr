<template>
  <div class="pt-3 px-3 bg-form">
    <div class="d-flex justify-content-between mx-2">
      <h3 class="form-title m-0">New Vault</h3>
      <i class="mdi mdi-close my-1 px-1 selectable rounded" data-bs-dismiss="modal"></i>
    </div>

    <form @submit.prevent="createVault()" class="p-3">
      <div class="row">
        <div class="col-6 px-1">
          <input required class="my-1 w-100" type="text" name="" id="" placeholder="Title..." v-model="editable.name">
        </div>
        <div class="col-6 px-1">
          <input required class="my-1 w-100" type="url" name="" id="" placeholder="Image URL..." v-model="editable.img">
        </div>
      </div>



      <div class="form-text text-end mt-4">Private vaults can only be seen by you.</div>
      <div class="mb-3 form-check d-flex justify-content-end">

        <input type="checkbox" class="form-check-input bg-secondary" id="exampleCheck1" v-model="editable.isPrivate">
        <label class="form-check-label px-2" for="exampleCheck1"> Make Vault Private?</label>
      </div>

      <div class="text-end ">
        <button class="btn btn-dark">Create</button>

      </div>
    </form>
  </div>
</template>

<script>
import { computed, ref } from "vue"
import { AppState } from "../AppState.js"
import { Modal } from "bootstrap"
import Pop from "../utils/Pop.js"
import { vaultsService } from "../services/VaultsService.js"
import { router } from "../router.js"

export default {
  setup() {
    // private variables and methods here
    const editable = ref({ isPrivate: false })
    return {
      editable,
      async createVault() {
        try {
          const vaultId = await vaultsService.createVault(editable.value)
          router.push('/vaults/' + vaultId)
          Modal.getOrCreateInstance('#create-vault').hide()
          editable.value = { isPrivate: false }
        } catch (error) {
          Pop.error(error)
        }
      }
      // public variables and methods here
    }
  },
}
</script>

<style></style>