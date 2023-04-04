import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultKeepsService {

    async createVaultKeep(vaultId, keepId) {
        const res = await api.post('api/vaultkeeps', { vaultId: vaultId, keepId: keepId })
        logger.log(res.data)
    }
}

export const vaultKeepsService = new VaultKeepsService();