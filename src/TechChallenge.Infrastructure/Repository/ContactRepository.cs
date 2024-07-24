using Infrastructure.Repository.EFRepository;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repository;

namespace TechChallenge.Infrastructure.Repository;
public class ContactRepository : EFRepository<Contact>, IContactRepository
{
  public ContactRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
  {

  }

  public async Task<Contact> UpdateContact(Contact contact)
  {
    var oldContact = await GetById(contact.Guid);
    
    oldContact.Name = contact.Name;
    oldContact.Phone = contact.Phone;
    oldContact.Region = contact.Region;
    oldContact.Email = contact.Email;

    //_context.Update(oldContact);
    await _context.SaveChangesAsync();
    return contact;
  }
}
