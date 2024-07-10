namespace TechChallenge.Domain.Entities;
public class Contact(string Name, string Email, int DDD, string Phone) : BaseEntity
{
  public string Name { get; } = Name;
  public string Email { get; } = Email;
  public int DDD { get; } = DDD;
  public string Phone { get; } = Phone;
}
