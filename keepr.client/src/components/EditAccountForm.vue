<template>
    <form @submit.prevent="editAccount()">
        <div class="mb-3">
            <label for="name" class="form-label">Username</label>
            <input v-model="editable.name" type="text" class="form-control" id="name" placeholder="Username...">
        </div>
        <div class="mb-3">
            <label for="picture" class="form-label">Profile Picture</label>
            <input v-model="editable.picture" type="text" class="form-control" id="picture" placeholder="Must be URL.">
        </div>
        <div class="mb-3">
            <label for="coverImg" class="form-label">Cover Image</label>
            <input v-model="editable.coverImg" type="text" class="form-control" id="coverImg" placeholder="Must be URL.">
        </div>
        <div class="text-end">
            <button class="btn btn-outline-success" type="submit" data-bs-dismiss="offcanvas">Save Changes</button>
        </div>
    </form>
</template>


<script>
import { ref } from 'vue';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { accountService } from '../services/AccountService';

export default {
    setup() {
        const editable = ref({ ...AppState.account })
        return {
            editable,

            async editAccount() {
                try {
                    const accountData = editable.value
                    await accountService.editAccount(accountData)
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