import { AppState } from "../AppState.js";
import { Vault } from "../models/Vault.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultsService {

    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        AppState.vaults.unshift(new Vault(res.data))
        // logger.log(AppState.vaults)
    }

    async getMyVaults() {
        const res = await api.get('account/vaults')
        AppState.myVaults = res.data.map(r => new Vault(r))
        // logger.log(AppState.myVaults)
    }

    async getVaultsByProfileId(profileId) {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.vaults = res.data.map(r => new Vault(r))
        // logger.log(AppState.vaults)
    }

    async getKeepsInVault(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        // logger.log(res.data)
    }
}

export const vaultsService = new VaultsService();