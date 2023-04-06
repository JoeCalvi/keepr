import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { Vault } from "../models/Vault.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";

class VaultsService {

    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        AppState.vaults.unshift(new Vault(res.data))
        AppState.myVaults.push(new Vault(res.data))
        Pop.toast(`Vault created!`, "success", "center", 3000, true)
        // logger.log(AppState.vaults)
    }

    async getVaultsByProfileId(profileId) {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.vaults = res.data.map(r => new Vault(r))
        // logger.log(AppState.vaults)
    }

    async getVaultById(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}`)
        AppState.activeVault = new Vault(res.data)
        // logger.log(AppState.activeVault)
    }

    async getKeepsInVault(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        AppState.keeps = res.data.map(r => new Keep(r))
        // logger.log(AppState.keeps)
    }

    async deleteVault(vaultId) {
        const res = await api.delete(`api/vaults/${vaultId}`)
        Pop.toast(`${res.data}`, "success", "center", 3000, true)
        const vaultIndex = AppState.myVaults.findIndex(v => v.id == vaultId)
        AppState.myVaults.splice(vaultIndex, 1)
    }
}

export const vaultsService = new VaultsService();