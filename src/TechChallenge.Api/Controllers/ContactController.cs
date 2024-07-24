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
    try
    {
      var result = await _contactService.CreateContact(request);
      if (result is not null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    catch (Exception ex)
    {
      return BadRequest(ex);
    }
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    try
    {
      var result = await _contactService.GetAll();

      if (result is not null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    catch (Exception ex)
    {
      return BadRequest(ex);
    }
  }

  [HttpDelete("{guid:Guid}")]
  public async Task<IActionResult> RemoveContact([FromRoute] Guid guid)
  {
    try
    {
      var result = await _contactService.Delete(guid);

      if (result is not null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    catch (Exception ex)
    {
      return BadRequest(ex);
    }
  }

  [HttpPut()]
  public async Task<IActionResult> UpdateContact([FromBody] ContactUpdateDTO contactDto)
  {
    try
    {
      var result = await _contactService.UpdateContact(contactDto);

      if (result is not null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    catch (Exception ex)
    {
      return BadRequest(ex);
    }
  }
}
