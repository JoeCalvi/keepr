import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Keep } from "../models/Keep.js";

class KeepsService {

    async getAllKeeps() {
        const res = await api.get('api/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
        logger.log(AppState.keeps)
    }
}

export const keepsService = new KeepsService();