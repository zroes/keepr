namespace keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _repo;

  public KeepsService(KeepsRepository repo)
  {
    _repo = repo;
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
    Keep keep = GetOne(keepId);
    keep.Creator = userInfo;
    return keep;
  }

  internal Keep GetOne(int keepId)
  {
    Keep keep = _repo.GetOne(keepId);
    if (keep == null)
      throw new Exception("that Id is invalid! -->" + keepId);
    return keep;
  }

  internal Keep Edit(Keep editData)
  {
    Keep keepToEdit = GetOne(editData.Id);
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
    Keep keepToDelete = GetOne(keepId);
    if (keepToDelete.CreatorId != creatorId)
      throw new Exception("You don't have permission to delete " + keepToDelete.Name);
    _repo.Delete(keepId);

    return $"{keepToDelete.Name} was successfully deleted";

  }
}
