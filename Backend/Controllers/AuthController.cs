using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("test")]
    public async Task<string> TestController()
    {
        // Simulate async work (optional)
        await Task.Delay(10);
        return "Hello from AuthController!";
    }
}

