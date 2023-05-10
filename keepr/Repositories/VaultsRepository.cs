namespace keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateVault(Vault vaultData)
  {
    string sql = @"
      INSERT INTO vaults
        (name, description, img, isPrivate, creatorId)
      VALUES
        (@Name, @Description, @Img, @IsPrivate, @CreatorId);
      SELECT LAST_INSERT_ID();
    ;";

    int vaultId = _db.ExecuteScalar<int>(sql, vaultData);
    return vaultId;
  }

  internal void Delete(int vaultId)
  {
    string sql = "DELETE FROM vaults WHERE id = @vaultId;";
    _db.Execute(sql, new { vaultId });
  }

  internal void Edit(Vault vaultToEdit)
  {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name,
    description = @Description,
    img = @Img,
    isPrivate = @IsPrivate
    WHERE id = @Id
    ;";
    _db.Execute(sql, vaultToEdit);
  }

  internal List<Vault> GetMyVaults(string creatorId)
  {
    string sql = @"
    SELECT *
    FROM vaults 
    WHERE vaults.creatorId = @creatorId;
    ;";
    List<Vault> vaults = _db.Query<Vault>(sql, new { creatorId }).ToList();
    return vaults;

  }

  internal Vault GetOne(int vaultId)
  {
    string sql = @"
    SELECT
    v.*,
    act.*
    FROM vaults v
    JOIN accounts act ON act.id = v.creatorId
    WHERE v.id = @vaultId
    ;";

    Vault vault = _db.Query<Vault, Account, Vault>(sql, (v, act) =>
    {
      v.Creator = act;
      return v;
    }, new { vaultId }).FirstOrDefault();

    return vault;
  }

  internal List<Vault> GetVaults(string profileId)
  {
    string sql = @"
    SELECT *
    FROM vaults 
    WHERE vaults.creatorId = @profileId;
    ;";
    List<Vault> vaults = _db.Query<Vault>(sql, new { profileId }).ToList();
    return vaults;
  }
}
