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
        const vault = AppState.vaults.find(v => v.id == vaultData.id)
        Pop.toast(`${vault.name} created!`, "success", "center", 3000, true)
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
        logger.log(AppState.activeVault)
    }

    async getKeepsInVault(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        AppState.keeps = res.data.map(r => new Keep(r))
        // logger.log(AppState.keeps)
    }

    async deleteKeep(keepId) {
        const res = await api.delete(`api/keeps/${keepId}`)
        const keep = AppState.keeps.find(k => k.id == keepId)
        Pop.toast(`${res.data}`, "success", "center", "3000", true)
        const keepIndex = AppState.keeps.findIndex(k => k.id == keepId)
        AppState.keeps.splice(keepIndex, 1)
    }
}

export const vaultsService = new VaultsService();