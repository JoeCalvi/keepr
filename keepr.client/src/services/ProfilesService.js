import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class ProfilesService {

    async getProfileById(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        AppState.profile = res.data
        logger.log(AppState.profile)
    }

}

export const profilesService = new ProfilesService();