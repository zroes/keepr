namespace keepr.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth;

  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth = auth;
  }


  [HttpPost]
  public async Task<ActionResult<VaultKeep>> CreateLink([FromBody] VaultKeep vkData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vkData.CreatorId = userInfo.Id;
      VaultKeep vaultKeep = _vaultKeepsService.CreateLink(vkData);
      return Ok(vaultKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{vaultKeepId}")]
  public async Task<ActionResult<string>> DeleteLink(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      string message = _vaultKeepsService.DeleteLink(vaultKeepId, userInfo);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}
