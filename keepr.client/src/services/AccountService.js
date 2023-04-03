import { AppState } from '../AppState.js'
import { Account } from '../models/Account.js'
import { Vault } from '../models/Vault.js'
import { logger } from '../utils/Logger.js'
import { api } from './AxiosService.js'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getMyVaults() {
    const res = await api.get('/account/vaults')
    AppState.vaults = res.data.map(r => new Vault(r))
    logger.log(AppState.vaults)
  }
}

export const accountService = new AccountService()
