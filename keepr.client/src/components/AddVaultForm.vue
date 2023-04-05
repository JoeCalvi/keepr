<template>
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="container-fluid">
                <div class="row mt-3">
                    <div class="d-flex justify-content-between mb-3">
                        <h1>Add your Vault</h1>
                        <button class="btn btn-close" data-bs-dismiss="modal"></button>
                    </div>
                    <div class="col-12">
                        <form @submit.prevent="createVault()">
                            <div class="mb-3">
                                <label for="name" class="form-label">Name</label>
                                <input required v-model="editable.name" maxlength="12" type="text" class="form-control"
                                    id="name" placeholder="Vault Name...">
                            </div>
                            <div class="mb-3">
                                <label for="img" class="form-label">Image URL</label>
                                <input required v-model="editable.img" type="text" class="form-control" id="img"
                                    placeholder="Vault Image URL...">
                            </div>
                            <div class="mb-3">
                                <label for="description" class="form-label">Vault Description</label>
                                <textarea required v-model="editable.description" class="form-control" id="description"
                                    rows="5"></textarea>
                            </div>
                            <div class="form-check d-flex justify-content-end mb-3">
                                <div>
                                    <input v-model="editable.isPrivate" class="form-check-input" type="checkbox"
                                        id="isPrivate">
                                    <label class="form-check-label" for="isPrivate">
                                        Is this vault private?
                                    </label>
                                </div>
                            </div>
                            <div class="d-flex justify-content-end mb-3">
                                <button class="btn btn-primary" type="submit">Add Vault</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { ref } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,

            async createVault() {
                try {
                    const vaultData = editable.value
                    await vaultsService.createVault(vaultData)
                    editable.value = {}
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>