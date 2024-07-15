using TechChallenge.Application.DTO;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repository;

namespace TechChallenge.Application.Services;
public class ContactService : IContactService
{
  private readonly IContactRepository _repository;

  public ContactService(IContactRepository repository)
  {
    _repository = repository;
  }

  public async Task<Contact> CreateContact(ContactCreationDTO contactDto)
  {    
     return await _repository.Create(contactDto.FromDTO());
  }

  public async Task<IList<Contact>> GetAll()
  {
    return await _repository.GetAll();
  }
}
