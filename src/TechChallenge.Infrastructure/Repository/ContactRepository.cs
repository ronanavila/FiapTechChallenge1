using Infrastructure.Repository.EFRepository;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repository;

namespace TechChallenge.Infrastructure.Repository;
public class ContactRepository : EFRepository<Contact>, IContactRepository
{
  public ContactRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
  {
  }
}
