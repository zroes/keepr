import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

  async addKeepToVault(vkData) {
    const res = await api.post('api/vaultkeeps', vkData)
    logger.log('[putting keep in vault]', res.data)
  }

  async removeFromVault(vkId) {
    const res = await api.delete('api/vaultkeeps/' + vkId)
    logger.log("[removed from vault]", res.data)
    AppState.keeps = AppState.keeps.filter(k => k.id != AppState.activeKeep.id)
  }

}

export const vaultKeepsService = new VaultKeepsService()