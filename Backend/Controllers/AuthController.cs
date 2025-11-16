using Microsoft.AspNetCore.Mvc;
using Backend.DTO;
using Backend.Services.Auth;
namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("test")]
    public async Task<string> TestController(LoginDTO user, AuthServices service)
    {
        var login = await service.ValidateUserAsync(user);
        return 
    }
}

