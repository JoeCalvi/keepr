namespace keepr.Controllers
{
    [ApiController]
    [Route("api/vaultkeeps")]
    public class VaultkeepsController : ControllerBase
    {
        private readonly VaultkeepsService _vaultkeepsService;
        private readonly VaultsService _vaultsService;
        private readonly Auth0Provider _auth;

        public VaultkeepsController(VaultkeepsService vaultkeepsService, Auth0Provider auth, VaultsService vaultsService)
        {
            _vaultkeepsService = vaultkeepsService;
            _auth = auth;
            _vaultsService = vaultsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              vaultKeepData.CreatorId = userInfo.Id;
              Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId);
              if(vault.CreatorId != userInfo.Id) throw new Exception("You cannot store keeps in this vault.");
              VaultKeep vaultKeep = _vaultkeepsService.CreateVaultKeep(vaultKeepData);
              return Ok(vaultKeep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("{vaultKeepId}")]
        public ActionResult<VaultKeep> GetVaultKeepById(int vaultKeepId)
        {
          try 
          {
            VaultKeep vaultKeep = _vaultkeepsService.GetVaultKeepById(vaultKeepId);
            return Ok(vaultKeep);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }

        [HttpDelete("{vaultKeepId}")]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> DeleteVaultKeep(int vaultKeepId)
        {
          try 
          {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            string message = _vaultkeepsService.DeleteVaultKeep(vaultKeepId, userInfo.Id);
            return Ok(message);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }
    }
}