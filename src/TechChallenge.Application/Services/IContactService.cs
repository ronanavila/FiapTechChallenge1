using TechChallenge.Application.DTO;
using TechChallenge.Domain.Contracts;

namespace TechChallenge.Application.Services;
public interface IContactService
{
  Task<IResponse> CreateContact(ContactCreationDTO contactDto);
  Task<IList<ContactResponseDTO>> GetAllContacts();
  Task<ContactResponseDTO> Delete(Guid guid);
  Task<ContactResponseDTO> UpdateContact(ContactUpdateDTO contactDto);
  Task<IEnumerable<ContactResponseDTO>> GetContactByRegion(int ddd);
}
