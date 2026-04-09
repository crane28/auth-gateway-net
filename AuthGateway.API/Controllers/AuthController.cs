using Microsoft.AspNetCore.Mvc;

namespace AuthGateway.API.Controllers;

[Route("[controller]")]
public class AuthController: ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        return Ok();    
    }

    [HttpPost("Login")]
    public IActionResult Login(string username, string password)
    {
        return Ok();
    }

    [HttpGet("consent")]
    public IActionResult Consent()
    {
        return Ok();    
    }
    
    [HttpPost("consent")]
    public IActionResult Consent(int i)
    {
        return Ok();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}