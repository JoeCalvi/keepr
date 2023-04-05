import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";

class VaultKeepsService {

    async createVaultKeep(vaultId, keepId) {
        const res = await api.post('api/vaultkeeps', { vaultId: vaultId, keepId: keepId })
        // logger.log(res.data)
    }

    async removeFromVault(vaultKeepId) {
        const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
        const vault = AppState.activeVault
        const keep = AppState.keeps.find(k => k.vaultKeepId == vaultKeepId)
        Pop.toast(`${keep.name} removed from ${vault.name}.`, "success", "center", 3000, true)
        const keepIndex = AppState.keeps.findIndex(k => k.vaultKeepId == vaultKeepId)
        AppState.keeps.splice(keepIndex, 1)
    }
}

export const vaultKeepsService = new VaultKeepsService();