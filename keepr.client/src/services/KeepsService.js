import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getAllKeeps() {
    AppState.profile = null
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.map(k => new Keep(k))
    logger.log("[GETTING KEEPS]", AppState.keeps)
  }

  async getKeepsInVault(vaultId) {
    AppState.keeps = null
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    AppState.keeps = res.data.map(k => new Keep(k))
    logger.log("[Getting keeps in vault]", AppState.keeps)
  }

  async setActive(keepId) {
    const res = await api.get('api/keeps/' + keepId)
    const keepActive = AppState.keeps.find(k => k.id == keepId)
    AppState.activeKeep = new Keep(res.data)
    AppState.activeKeep.vaultKeepId = keepActive.vaultKeepId
    logger.log('[setting active]', AppState.activeKeep)
    // AppState.activeKeep.views++
  }

  async createKeep(keepData, profileId) {
    logger.log("[Creating keep]", keepData)
    const res = await api.post('api/keeps', keepData)
    // FIXME if there's a profileId AND it's not the user id  don't push it into this array
    if (profileId && profileId != AppState.user.id) return
    AppState.keeps.push(new Keep(res.data))
  }

  async deleteKeep(keepId) {
    const res = await api.delete('api/keeps/' + keepId)
    logger.log("[deleting keep]", res.data)
    AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
  }

}

export const keepsService = new KeepsService()