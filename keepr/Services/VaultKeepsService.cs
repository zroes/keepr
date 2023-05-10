namespace keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
  {
    _repo = repo;
    _vaultsService = vaultsService;
  }

  internal VaultKeep CreateLink(VaultKeep vkData)
  {
    Vault vault = _vaultsService.GetOne(vkData.VaultId, vkData.CreatorId);
    if (vault.CreatorId != vkData.CreatorId)
      throw new Exception("You can't do that");
    int id = _repo.Link(vkData);
    vkData.Id = id;
    return vkData;
  }

  internal VaultKeep GetOne(int vaultKeepId)
  {
    VaultKeep vaultKeep = _repo.GetOne(vaultKeepId);
    if (vaultKeep == null)
      throw new Exception("No VaultKeep found at id " + vaultKeepId);
    return vaultKeep;
  }

  internal string DeleteLink(int vaultKeepId, Account userInfo)
  {
    VaultKeep vkToDelete = GetOne(vaultKeepId);
    if (vkToDelete.CreatorId != userInfo.Id)
      throw new Exception("You don't have permission to delete this vaultkeep");

    _repo.DeleteLink(vaultKeepId);
    return "deletion successful";
  }

  internal List<KeepInVault> GetKeepsInVault(int vaultId, string userId)
  {
    Vault vault = _vaultsService.GetOne(vaultId, userId);
    // if (vault.CreatorId != userId && vault.IsPrivate == true)
    // throw new Exception("You cannot access the keeps in this vault");
    List<KeepInVault> keepsInVault = _repo.GetKeepsInVault(vaultId);
    return keepsInVault;
  }
}
