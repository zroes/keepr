namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly ProfilesService _profilesService;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;

  public ProfilesController(ProfilesService profilesService, KeepsService keepsService, VaultsService vaultsService)
  {
    _profilesService = profilesService;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
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
}
