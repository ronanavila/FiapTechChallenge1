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
      var result  = await _contactService.CreateContact(request);

      return Ok(result);
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

      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest(ex);
    }
  }
}
