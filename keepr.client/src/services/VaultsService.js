import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {


  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log("[Creating Vault]", res.data)
    AppState.activevault = new Vault(res.data)
    return res.data.id
  }

  async deleteVault(vaultId) {
    const res = await api.delete('api/vaults/' + vaultId)
    logger.log("[Vault deleted]", res.data)
  }

  async getVault(vaultId) {
    const res = await api.get('api/vaults/' + vaultId)
    logger.log('[GETTING vault]')
    AppState.activeVault = new Vault(res.data)
  }

  async toggleVis(isPrivate, vaultId) {
    isPrivate = !isPrivate
    const res = await api.put('api/vaults/' + vaultId, { isPrivate })
    logger.log("[Toggled]", res.data)
    AppState.activeVault.isPrivate = isPrivate
  }
}

export const vaultsService = new VaultsService()