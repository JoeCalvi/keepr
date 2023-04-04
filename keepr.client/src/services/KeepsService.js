import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Keep } from "../models/Keep.js";

class KeepsService {

    async getAllKeeps() {
        const res = await api.get('api/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
        // logger.log(AppState.keeps)
    }

    async getKeepsByProfileId(profileId) {
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        AppState.keeps = res.data.map(r => new Keep(r))
        logger.log(AppState.keeps)
    }

    async setActiveKeep(keepId) {
        const res = await api.get(`api/keeps/${keepId}`)
        AppState.activeKeep = new Keep(res.data)
        // logger.log(AppState.activeKeep)
    }

    async createKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        logger.log(res.data)
    }
}

export const keepsService = new KeepsService();