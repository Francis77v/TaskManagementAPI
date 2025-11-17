using Microsoft.AspNetCore.Mvc;
using Backend.DTO;
using Backend.Services.Auth;
namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> TestController(LoginDTO user, [FromServices] AuthServices service)
    {
        try
        {
            var login = await service.ValidateUserAsync(user);
            return Ok(login);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

}

