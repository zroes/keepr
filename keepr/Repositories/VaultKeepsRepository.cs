namespace keepr.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal void DeleteLink(int vaultKeepId)
  {
    string sql = "DELETE FROM vaultkeeps WHERE id = @vaultKeepId";

    _db.Execute(sql, new { vaultKeepId });
  }

  internal List<KeepInVault> GetKeepsInVault(int vaultId)
  {
    string sql = @"
    SELECT
    vk.*, k.*, acct.*
    FROM vaultkeeps vk
    JOIN keeps k ON vk.keepId = k.id
    JOIN accounts acct ON k.creatorId = acct.id
    WHERE vk.vaultId = @vaultId
    ;";

    List<KeepInVault> keeps = _db.Query<VaultKeep, KeepInVault, Profile, KeepInVault>(sql, (vk, k, acct) =>
    {
      k.VaultKeepId = vk.Id;
      k.Creator = acct;
      return k;
    }, new { vaultId }).ToList();

    return keeps;
  }

  internal VaultKeep GetOne(int vaultKeepId)
  {
    string sql = "SELECT * FROM vaultkeeps WHERE id = @vaultKeepId;";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
    return vaultKeep;
  }

  internal int Link(VaultKeep vkData)
  {
    string sql = @"
    INSERT INTO vaultkeeps
      (creatorId, vaultId, keepId)
    VALUES
      (@CreatorId, @VaultId, @KeepId);
    SELECT LAST_INSERT_ID();
    ;";
    int id = _db.ExecuteScalar<int>(sql, vkData);
    return id;
  }
}
