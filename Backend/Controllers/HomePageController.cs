using Backend.DTO.AuthDTO;
using Microsoft.AspNetCore.Mvc;
using Backend.Services.Auth;
using Backend.Services;
namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomePageController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> TestController(LoginDTO user, [FromServices] AuthServices service)
    {
        try
        {
            var login = await service.ValidateUserAsync(user);
            return StatusCode(login.statusCode, login);
        }
        catch (Exception e)
        {
            return StatusCode(500, new APIResponseDTO<object>
            {
                success = false,
                statusCode = 500,
                message = e.Message,
                data = null,
                Errors = new List<string> {e.Message}
            });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO user, [FromServices] UserServices service)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await service.registerUser(user);
        return Ok(result);
    }


}

