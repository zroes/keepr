namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth;

  public KeepsController(KeepsService keepsService, Auth0Provider auth)
  {
    _keepsService = keepsService;
    _auth = auth;
  }


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Keep>> PostKeep([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.PostKeep(keepData, userInfo);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Keep>> GetAll()
  {
    try
    {
      List<Keep> keeps = _keepsService.GetAll();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{keepId}")]
  public ActionResult<Keep> GetOne(int keepId)
  {
    try
    {
      //Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.GetOne(keepId, true);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpPut("{keepId}")]
  public async Task<ActionResult<Keep>> Edit([FromBody] Keep editData, int keepId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      editData.CreatorId = userInfo.Id;
      editData.Id = keepId;
      Keep keep = _keepsService.Edit(editData);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("{keepId}")]
  public async Task<ActionResult<string>> Delete(int keepId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      string message = _keepsService.Delete(keepId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
