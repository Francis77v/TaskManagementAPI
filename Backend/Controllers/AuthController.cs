using Backend.DTO.AuthDTO;
using Microsoft.AspNetCore.Mvc;
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
            return StatusCode(login.statusCode, login);
        }
        catch (Exception e)
        {
            return StatusCode(500, new APIResponseDTO<object>
            {
                success = false,
                statusCode = 500,
                message = "An unexpected error occurred",
                data = null,
                Errors = new List<ErrorDetailDTO>
                {
                    new ErrorDetailDTO { field = null, error = e.Message }
                }
            });
        }
    }


}

