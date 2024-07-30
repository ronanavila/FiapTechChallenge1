using System.Text.Json;
using TechChallenge.Application.DTO;
using TechChallenge.Application.Mapping;
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

  public async Task<ContactResponseDTO> CreateContact(ContactCreationDTO contactDto)
  {
    var contact = ContactMapping.FromCreationDTO(contactDto);
    var contactResponse = await _repository.Create(contact);
    ContactResponseDTO? contactResponseDto = ContactMapping.ToResponseDTO(contactResponse);
    return contactResponseDto;
  }

  public async Task<IList<ContactResponseDTO>> GetAll()
  {
    var contatos = await _repository.GetAll();

    var contatosDtos = new List<ContactResponseDTO>();

    foreach (var contato in contatos)
    {
      contatosDtos.Add(ContactMapping.ToResponseDTO(contato));
    }
    return contatosDtos;
  }
  public async Task<ContactResponseDTO> Delete(Guid guid)
  {
    var contato = await _repository.Delete(guid);

    return ContactMapping.ToResponseDTO(contato);
  }

  public async Task<ContactResponseDTO> UpdateContact(ContactUpdateDTO contactDto)
  {
    var contacto = ContactMapping.FromUpdateDTO(contactDto);
    var contatoResponse = await _repository.UpdateContact(contacto);
    var contactoResponseDto = ContactMapping.ToResponseDTO(contatoResponse);
    return contactoResponseDto;
  }

  public async Task<IEnumerable<ContactResponseDTO>> GetContactByRegion(int ddd)
  {

    var contatosResponseDto = new List<ContactResponseDTO>();

    var contatoResponse = await _repository.GetContactByRegion(ddd);

    if (!contatoResponse.Any())
    {
      return contatosResponseDto;
    }

    foreach (var contato in contatoResponse) {
      contatosResponseDto.Add(ContactMapping.ToResponseDTO(contato));
    }

    return contatosResponseDto;

  }
}
