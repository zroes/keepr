namespace keepr.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal void Delete(int keepId)
  {
    string sql = @"
    DELETE FROM keeps WHERE id = @keepId
    ;";

    _db.Execute(sql, new { keepId });
  }

  internal void Edit(Keep keepToEdit)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    description = @Description,
    img = @Img
    WHERE id = @Id
    ;";
    _db.Execute(sql, keepToEdit);
  }

  internal List<Keep> GetAll()
  {
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    act.*
    FROM keeps k
    JOIN accounts act ON act.id = k.creatorId
    LEFT JOIN vaultkeeps vk on vk.keepId = k.id
    GROUP BY (k.id)
    ;";
    List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (k, act) =>
    {
      k.Creator = act;
      return k;
    }).ToList();
    return keeps;
  }

  internal List<Keep> GetKeeps(string profileId)
  {
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    act.*
    FROM keeps k
    JOIN accounts act ON act.id = k.creatorId
    LEFT JOIN vaultkeeps vk ON vk.keepId = k.id
    WHERE k.creatorId = @profileId
    GROUP BY (k.id)
    ;";
    List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (k, act) =>
    {
      k.Creator = act;
      return k;
    }, new { profileId }).ToList();

    return keeps;
  }

  internal Keep GetOne(int keepId, bool check)
  {
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    act.*
    FROM keeps k
    JOIN accounts act ON act.id = k.creatorId
    LEFT JOIN vaultkeeps vk on vk.keepId = k.id
    WHERE k.id = @keepId
    GROUP BY (k.id)
    ;";

    Keep keep = _db.Query<Keep, Account, Keep>(sql, (k, act) =>
    {
      k.Creator = act;
      return k;
    }, new { keepId }).FirstOrDefault();


    if (check)
    {
      keep.Views = keep.Views + 1;
      sql = @"
    UPDATE keeps
    SET
    views = @Views
    WHERE id = @Id
    ;";
      _db.Execute(sql, keep);
    }

    return keep;
  }

  internal int PostKeep(Keep keepData)
  {
    string sql = @"
      INSERT INTO keeps
        (name, description, img, creatorId, views)
      VALUES
        (@Name, @Description, @Img, @CreatorId, @Views);
      SELECT LAST_INSERT_ID();
    ;";

    int keepId = _db.ExecuteScalar<int>(sql, keepData);
    return keepId;
  }
}
