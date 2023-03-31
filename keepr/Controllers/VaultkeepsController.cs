namespace keepr.Controllers
{
    [ApiController]
    [Route("api/vaultkeeps")]
    public class VaultkeepsController : ControllerBase
    {
        private readonly VaultkeepsService _vaultkeepsService;
        private readonly Auth0Provider _auth;

        public VaultkeepsController(VaultkeepsService vaultkeepsService, Auth0Provider auth)
        {
            _vaultkeepsService = vaultkeepsService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              vaultKeepData.CreatorId = userInfo.Id;
              VaultKeep vaultKeep = _vaultkeepsService.CreateVaultKeep(vaultKeepData);
              return Ok(vaultKeep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}