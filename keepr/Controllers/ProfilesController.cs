namespace keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;
        private readonly Auth0Provider _auth;

        public ProfilesController(ProfilesService profilesService, Auth0Provider auth)
        {
            _profilesService = profilesService;
            _auth = auth;
        }

        [HttpGet("{profileId}")]
        public ActionResult<Profile> GetProfileById(string profileId)
        {
            try 
            {
              Profile profile = _profilesService.GetProfileById(profileId);
              return Ok(profile);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}