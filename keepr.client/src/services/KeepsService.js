import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Keep } from "../models/Keep.js";
import Pop from "../utils/Pop.js";

class KeepsService {

    async getAllKeeps() {
        const res = await api.get('api/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
        // logger.log(AppState.keeps)
    }

    async getKeepsByProfileId(profileId) {
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        AppState.keeps = res.data.map(r => new Keep(r))
        // logger.log(AppState.keeps)
    }

    async setActiveKeep(keepId) {
        const res = await api.get(`api/keeps/${keepId}`)
        AppState.activeKeep = new Keep(res.data)
        logger.log(res.data)
    }

    async createKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        AppState.keeps.unshift(new Keep(res.data))
        // logger.log(AppState.keeps)
    }

    async deleteKeep(keepId) {
        const res = await api.delete(`api/keeps/${keepId}`)
        Pop.toast(`${res.data}`, "success", "center", 3000, true)
        const keepIndex = AppState.keeps.findIndex(k => k.id == keepId)
        AppState.keeps.splice(keepIndex, 1)
    }
}

export const keepsService = new KeepsService();