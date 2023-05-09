import { AppState } from "../AppState.js"
import { Profile } from "../models/Account.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProfilesService {

  async getProfile(profileId) {
    AppState.profile = null
    const res = await api.get('api/profiles/' + profileId)
    logger.log("[Getting Profile]", res.data)
    AppState.profile = new Profile(res.data)
  }

  async updateProfile(profileData) {
    AppState.profile = null
    const res = await api.put('api/profiles', profileData)
    logger.log("[Profile Updated]", res.data)
    AppState.profile = new Profile(res.data)
  }

  async getKeeps(profileId) {
    AppState.keeps = []
    const res = await api.get('api/profiles/' + profileId + '/keeps')
    logger.log("Getting Keeps", res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async getVaults(profileId) {
    AppState.vaults = []
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    logger.log("Getting Vaults", res.data)
    AppState.vaults = res.data.map(v => new Vault(v))
  }
}

export const profilesService = new ProfilesService()