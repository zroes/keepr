namespace keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;

  public VaultKeepsService(VaultKeepsRepository repo)
  {
    _repo = repo;
  }

  internal VaultKeep CreateLink(VaultKeep vkData)
  {
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

  internal List<KeepInVault> GetKeepsInVault(int vaultId, string id)
  {
    List<KeepInVault> keepsInVault = _repo.GetKeepsInVault(vaultId);
    return keepsInVault;
  }
}
