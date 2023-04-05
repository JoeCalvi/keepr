import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultKeepsService {

    async createVaultKeep(vaultId, keepId) {
        const res = await api.post('api/vaultkeeps', { vaultId: vaultId, keepId: keepId })
        // logger.log(res.data)
    }

    async removeFromVault(vaultKeepId) {
        const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
        logger.log(res.data)
        const keepIndex = AppState.keeps.findIndex(k => k.vaultKeepId == vaultKeepId)
        AppState.keeps.splice(keepIndex, 1)
    }
}

export const vaultKeepsService = new VaultKeepsService();