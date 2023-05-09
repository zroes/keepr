namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly ProfilesService _profilesService;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth;

  public ProfilesController(ProfilesService profilesService, KeepsService keepsService, VaultsService vaultsService, Auth0Provider auth)
  {
    _profilesService = profilesService;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
    _auth = auth;
  }


  [HttpGet("{profileId}")]
  public ActionResult<Profile> GetProfile(string profileId)
  {
    try
    {
      Profile prof = _profilesService.GetProfile(profileId);
      return prof;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{profileId}/keeps")]
  public ActionResult<List<Keep>> GetKeeps(string profileId)
  {
    try
    {
      List<Keep> keeps = _keepsService.GetKeeps(profileId);
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public ActionResult<List<Vault>> GetVaults(string profileId)
  {
    try
    {
      List<Vault> vaults = _vaultsService.GetVaults(profileId);
      return Ok(vaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpPut]
  public async Task<ActionResult<Profile>> UpdateProfile([FromBody] Profile profileData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Profile prof = _profilesService.UpdateProfile(userInfo.Id, profileData);
      return Ok(prof);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
