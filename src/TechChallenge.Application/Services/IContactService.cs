using TechChallenge.Application.DTO;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Services;
public interface IContactService
{
  Task<ContactResponseDTO> CreateContact(ContactCreationDTO contactDto);
  Task<IList<ContactResponseDTO>> GetAll();
  Task<ContactResponseDTO> Delete(Guid guid);
  Task<ContactResponseDTO> UpdateContact(ContactUpdateDTO contactDto);
}
