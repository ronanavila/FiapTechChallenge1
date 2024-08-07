using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.DTO;
using TechChallenge.Application.Services;

namespace TechChallenge.Api.Controllers;
[Route("api/contacts")]
[ApiController]
public class ContactController : ControllerBase
{
  private readonly IContactService _contactService;

  public ContactController(IContactService contactService)
  {
    _contactService = contactService;
  }

  [HttpPost]
  public async Task<IActionResult> CreateContact([FromBody] ContactCreationDTO request)
  {

    var result = await _contactService.CreateContact(request);

    return StatusCode((int)result.StatusCode, result);
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var result = await _contactService.GetAllContacts();

    return StatusCode((int)result.StatusCode, result);
  }

  [HttpGet("{ddd:int}")]
  public async Task<IActionResult> GetContactByRegion([FromRoute] int ddd)
  {

    var result = await _contactService.GetContactByRegion(ddd);

    return StatusCode((int)result.StatusCode, result);

  }

  [HttpDelete("{guid:Guid}")]
  public async Task<IActionResult> RemoveContact([FromRoute] Guid guid)
  {

    var result = await _contactService.Delete(guid);

    return StatusCode((int)result.StatusCode, result);
  }

  [HttpPut()]
  public async Task<IActionResult> UpdateContact([FromBody] ContactUpdateDTO contactDto)
  {

    var result = await _contactService.UpdateContact(contactDto);

    return StatusCode((int)result.StatusCode, result);
  }
}
