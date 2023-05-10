import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {


  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log("[Creating Vault]", res.data)
    AppState.vaults.push(new Vault(res.data))
  }

  async getVault(vaultId) {
    const res = await api.get('api/vaults/' + vaultId)
    logger.log('[GETTING vault]')
    AppState.activeVault = new Vault(res.data)
  }
}

export const vaultsService = new VaultsService()