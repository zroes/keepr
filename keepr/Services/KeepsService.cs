namespace keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _repo;
  private readonly VaultsService _vaultsService;
  public KeepsService(KeepsRepository repo, VaultsService vaultsService)
  {
    _repo = repo;
    _vaultsService = vaultsService;
  }

  internal List<Keep> GetAll()
  {
    List<Keep> keeps = _repo.GetAll();
    return keeps;
  }

  internal Keep PostKeep(Keep keepData, Account userInfo)
  {
    keepData.CreatorId = userInfo.Id;
    int keepId = _repo.PostKeep(keepData);
    Keep keep = GetOne(keepId, false);
    keep.Creator = userInfo;
    return keep;
  }

  internal Keep GetOne(int keepId, bool check)
  {
    Keep keep = _repo.GetOne(keepId, check);
    if (keep == null)
      throw new Exception("that Id is invalid! -->" + keepId);
    return keep;
  }

  internal Keep Edit(Keep editData)
  {
    Keep keepToEdit = GetOne(editData.Id, false);
    if (keepToEdit.CreatorId != editData.CreatorId)
      throw new Exception("You don't have permission to edit " + keepToEdit.Name);

    keepToEdit.Name = editData.Name ?? keepToEdit.Name;
    keepToEdit.Description = editData.Description ?? keepToEdit.Description;
    keepToEdit.Img = editData.Img ?? keepToEdit.Img;

    _repo.Edit(keepToEdit);

    return keepToEdit;

  }

  internal string Delete(int keepId, string creatorId)
  {
    Keep keepToDelete = GetOne(keepId, false);
    if (keepToDelete.CreatorId != creatorId)
      throw new Exception("You don't have permission to delete " + keepToDelete.Name);
    _repo.Delete(keepId);

    return $"{keepToDelete.Name} was successfully deleted";

  }

  internal List<Keep> GetKeeps(string profileId)
  {
    List<Keep> keeps = _repo.GetKeeps(profileId);
    return keeps;
  }
}
