using Microsoft.AspNetCore.Mvc;

namespace AuthGateway.API.Controllers;

[Route("[controller]")]
public class AuthController: ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login()
    {
        
        return Ok();
    }

    [HttpPost("register")]
    public IActionResult Register()
    {
        return Ok();
    }
}