namespace keepr.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _repo;

  public ProfilesService(ProfilesRepository repo)
  {
    _repo = repo;
  }

  internal Profile GetProfile(string profileId)
  {
    Profile prof = _repo.GetProfile(profileId);
    if (prof == null)
      throw new Exception("invalid id");
    return prof;
  }

  internal Profile UpdateProfile(string profileId, Profile profileData)
  {
    Profile profToEdit = GetProfile(profileId);
    profToEdit.Name = profileData.Name ?? profToEdit.Name;
    profToEdit.CoverImg = profileData.CoverImg ?? profToEdit.CoverImg;
    profToEdit.Picture = profileData.Picture ?? profToEdit.Picture;

    _repo.UpdateProfile(profToEdit);
    return profToEdit;
  }
}
