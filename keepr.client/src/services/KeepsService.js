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

  async setActive(keepId) {
    const res = await api.get('api/keeps/' + keepId)
    logger.log('[setting active]', res.data)
    AppState.activeKeep = new Keep(res.data)
    // AppState.activeKeep = AppState.keeps.find(k => k.id == keepId)
    // AppState.activeKeep.views++
  }

  async createKeep(keepData) {
    logger.log("[Creating keep]", keepData)
    const res = await api.post('api/keeps', keepData)
    AppState.keeps.push(new Keep(res.data))
  }

}

export const keepsService = new KeepsService()