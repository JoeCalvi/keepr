namespace keepr.Controllers
{
    [ApiController]
    [Route("api/vaults")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vaultsService;
        private readonly Auth0Provider _auth;
        private readonly KeepsService _keepsService;

        public VaultsController(VaultsService vaultsService, Auth0Provider auth, VaultkeepsService vaultkeepsService, KeepsService keepsService)
        {
            _vaultsService = vaultsService;
            _auth = auth;
            _keepsService = keepsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              vaultData.CreatorId = userInfo.Id;
              Vault vault = _vaultsService.CreateVault(vaultData);
              vaultData.Creator = userInfo;
              return Ok(vault);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("{vaultId}")]
        public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              Vault vault = _vaultsService.GetVaultById(vaultId);
              if(vault.IsPrivate == true && vault.CreatorId != userInfo.Id) throw new Exception("This vault is private.");
              return Ok(vault);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("{vaultId}/keeps")]
        public async Task<ActionResult<List<Keep>>> GetKeepsByVaultId(int vaultId)
        {
          try 
          {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            Vault vault = _vaultsService.GetVaultById(vaultId);
            if(vault.IsPrivate == true && vault.CreatorId != userInfo.Id) throw new Exception("This vault is private.");
            List<Keep> keeps = _keepsService.GetKeepsByVaultId(vaultId);
            return Ok(keeps);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }

        [HttpPut("{vaultId}")]
        [Authorize]
        public async Task<ActionResult<Vault>> EditVault([FromBody] Vault vaultData, int vaultId)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              vaultData.Id = vaultId;
              Vault vault = _vaultsService.EditVault(vaultData, userInfo.Id);
              return Ok(vault);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpDelete("{vaultId}")]
        [Authorize]
        public async Task<ActionResult<Vault>> DeleteVault(int vaultId)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              string message = _vaultsService.DeleteVault(vaultId, userInfo.Id);
              return Ok(message);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}