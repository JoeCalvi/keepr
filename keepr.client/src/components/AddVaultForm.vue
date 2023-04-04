<template>
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="container-fluid">
                <div class="row mt-3">
                    <div class="d-flex justify-content-between mb-3">
                        <h1>Add your Keep</h1>
                        <button class="btn btn-close"></button>
                    </div>
                    <div class="col-12">
                        <form @submit.prevent="createKeep()">
                            <div class="mb-3">
                                <label for="name" class="form-label">Name</label>
                                <input required v-model="editable.name" type="text" class="form-control" id="name"
                                    placeholder="Keep Name...">
                            </div>
                            <div class="mb-3">
                                <label for="img" class="form-label">Image URL</label>
                                <input required v-model="editable.img" type="text" class="form-control" id="img"
                                    placeholder="Keep Image URL...">
                            </div>
                            <!-- <div class="mb-3">
                                <label for="tags" class="form-label">Tags</label>
                                <input type="text" class="form-control" id="tags"
                                    placeholder="Seperate tags with commas.">
                            </div> -->
                            <div class="mb-3">
                                <label for="description" class="form-label">Keep Description</label>
                                <textarea required v-model="editable.description" class="form-control" id="description"
                                    rows="5"></textarea>
                            </div>
                            <div class="d-flex justify-content-end mb-3">
                                <button class="btn btn-primary" type="submit">Add Keep</button>
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