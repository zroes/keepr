namespace keepr.Models;

public class Generic
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public Profile Creator { get; set; }
}

public class Keep : Generic
{
  public int Views { get; set; }
  public int Kept { get; set; }

}

public class KeepInVault : Keep
{
  public int VaultKeepId { get; set; }
}
