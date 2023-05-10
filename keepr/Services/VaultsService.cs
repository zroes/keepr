namespace keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _repo;

  public VaultsService(VaultsRepository repo)
  {
    _repo = repo;
  }

  internal Vault CreateVault(Vault vaultData, Account userInfo)
  {
    vaultData.CreatorId = userInfo.Id;
    int vaultId = _repo.CreateVault(vaultData);
    Vault newVault = GetOne(vaultId, userInfo.Id);
    return newVault;
  }

  internal string DeleteVault(int vaultId, Account userInfo)
  {
    Vault vaultToDelete = GetOne(vaultId, userInfo.Id);
    if (vaultToDelete.CreatorId != userInfo.Id)
      throw new Exception("You can't delete someone else's vault");

    _repo.Delete(vaultId);

    return $"{vaultToDelete.Name} was successfully deleted!";
  }

  internal Vault Edit(Vault editData)
  {
    Vault vaultToEdit = GetOne(editData.Id, editData.CreatorId);
    if (vaultToEdit.CreatorId != editData.CreatorId)
      throw new Exception("You don't have permission to edit " + vaultToEdit.Name);

    vaultToEdit.Name = editData.Name ?? vaultToEdit.Name;
    vaultToEdit.Description = editData.Description ?? vaultToEdit.Description;
    vaultToEdit.Img = editData.Img ?? vaultToEdit.Img;
    vaultToEdit.IsPrivate = editData.IsPrivate != null ? editData.IsPrivate : vaultToEdit.IsPrivate;

    _repo.Edit(vaultToEdit);

    return vaultToEdit;
  }

  internal List<Vault> GetMyVaults(string creatorId)
  {
    List<Vault> vaults = _repo.GetMyVaults(creatorId);
    return vaults;
  }

  internal Vault GetOne(int vaultId, string creatorId)
  {
    Vault vault = _repo.GetOne(vaultId);
    if (vault == null)
      throw new Exception("No vault found at id " + vaultId);
    if (vault.IsPrivate == true && vault.CreatorId != creatorId)
      throw new Exception("No vault found at id " + vaultId);
    return vault;
  }

  internal List<Vault> GetVaults(string profileId)
  {
    List<Vault> vaults = _repo.GetVaults(profileId);
    return vaults;
  }
}
