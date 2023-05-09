<template>
  <!-- Modal Body -->
  <!-- if you want to close by clicking outside the modal, delete the last endpoint:data-bs-backdrop and data-bs-keyboard -->
  <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
    <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered" :class="size" role="document">
      <div class="modal-content">
        <!-- <div class="modal-header">
          <h5 class="modal-title" id="modalTitleId">
            <slot name="header">Cool stuff</slot>
          </h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div> -->
        <div class="modal-body">
          <slot name="body">you forgot to put a body in</slot>
        </div>

      </div>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({ size: { type: String, default: 'modal-md' } })
</script>

<style scoped>
.modal-body {
  padding: 0;
}
</style>