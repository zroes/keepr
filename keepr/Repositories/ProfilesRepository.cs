namespace keepr.Repositories;

public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetProfile(string profileId)
  {
    string sql = "SELECT * FROM accounts WHERE id = @profileId;";
    Profile prof = _db.Query<Profile>(sql, new { profileId }).FirstOrDefault();
    return prof;
  }

  internal void UpdateProfile(Profile profToEdit)
  {
    string sql = @"
    UPDATE accounts
    SET
    name = @Name,
    picture = @Picture,
    coverImg = @CoverImg
    WHERE id = @Id
    ;";
    _db.Execute(sql, profToEdit);
  }
}
