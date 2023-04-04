<template></template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';
import { onMounted } from 'vue';

export default {
    setup() {
        const route = useRoute()
        const router = useRouter()

        async function getKeepsInVault() {
            try {
                const vaultId = route.params.vaultId
                await vaultsService.getKeepsInVault(vaultId)
            } catch (error) {
                logger.log(error)
                Pop.error(error)
                router.push({ name: 'Home' })
            }
        }

        onMounted(() => {
            getKeepsInVault();
        })
        return {}
    }
}
</script>


<style lang="scss" scoped></style>