namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;

  public VaultKeepsController(VaultKeepsService vaultKeepsService)
  {
    _vaultKeepsService = vaultKeepsService;
  }
}
