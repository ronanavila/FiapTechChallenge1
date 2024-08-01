using System.Text.Json;
using TechChallenge.Application.DTO;
using TechChallenge.Application.Mapping;
using TechChallenge.Domain.Contracts;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repository;
using TechChallenge.Domain.Shared;

namespace TechChallenge.Application.Services;
public class ContactService : IContactService
{
  private readonly IContactRepository _repository;

  public ContactService(IContactRepository repository)
  {
    _repository = repository;
  }

  public async Task<IResponse> CreateContact(ContactCreationDTO contactDto)
  {
   

    contactDto.Validate();

    if (!contactDto.IsValid)
    {
      return new BaseResponse(false, contactDto.Notifications);
    }

    var contact = ContactMapping.FromCreationDTO(contactDto);
    var contactResponse = await _repository.CreateContact(contact);

    return  new BaseResponse(true, "Cadastro realizado.", contactResponse); ;
  }

  public async Task<IList<ContactResponseDTO>> GetAllContacts()
  {
    var contacts = await _repository.GetAllContacts();

    var contactsDTO = new List<ContactResponseDTO>();

    foreach (var contact in contacts)
    {
      contactsDTO.Add(ContactMapping.ToResponseDTO(contact));
    }
    return contactsDTO;
  }
  public async Task<ContactResponseDTO> Delete(Guid guid)
  {
    var contact = await _repository.Delete(guid);

    return ContactMapping.ToResponseDTO(contact);
  }

  public async Task<ContactResponseDTO> UpdateContact(ContactUpdateDTO contactDto)
  {
    var contact = ContactMapping.FromUpdateDTO(contactDto);
    var contactResponse = await _repository.UpdateContact(contact);
    var contactResponseDto = ContactMapping.ToResponseDTO(contactResponse);
    return contactResponseDto;
  }

  public async Task<IEnumerable<ContactResponseDTO>> GetContactByRegion(int ddd)
  {

    var contactResponseDto = new List<ContactResponseDTO>();

    var contactResponse = await _repository.GetContactByRegion(ddd);

    if (!contactResponse.Any())
    {
      return contactResponseDto;
    }

    foreach (var contact in contactResponse)
    {
      contactResponseDto.Add(ContactMapping.ToResponseDTO(contact));
    }

    return contactResponseDto;

  }
}
