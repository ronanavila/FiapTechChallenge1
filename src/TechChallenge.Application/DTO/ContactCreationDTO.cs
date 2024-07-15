using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.DTO;
public record ContactCreationDTO(string Name, string Email, int DDD, string Phone)
{
  public ContactCreationDTO ToDto(Contact contact)
  {
    if (contact != null)
    {
      return new ContactCreationDTO(contact.Name, contact.Email, contact.DDD, contact.Phone);
    }

    return null;

  }

  public Contact FromDTO()
  {
    return new Contact(Name, Email, DDD, Phone);
  }
}


