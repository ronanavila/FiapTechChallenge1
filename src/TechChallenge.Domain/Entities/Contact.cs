
namespace TechChallenge.Domain.Entities;
public class Contact : BaseEntity
{
  public string Name { get; set; } 
  public string Email { get; set; } 
  public string Phone { get; set; }
  public int RegionDDD { get; set; }

  public virtual Region Region { get; set; }
}