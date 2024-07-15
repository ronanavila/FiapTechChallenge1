using TechChallenge.Application.DTO;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Services;
public interface IContactService
{
  Task<Contact> CreateContact(ContactCreationDTO contactDto);
  Task<IList<Contact>> GetAll();
}
