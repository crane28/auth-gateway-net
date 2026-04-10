using Microsoft.AspNetCore.Mvc;

namespace AuthGateway.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OAuthController: ControllerBase
{
    [HttpGet("authorize")]
    public IActionResult Authorize()
    {
        return Ok();
    }

    [HttpPost("token")]
    public IActionResult Token()
    {
        return Ok();
    }

    [HttpGet("userinfo")]
    public IActionResult UserInfo()
    {
        return Ok();
    }

    [HttpPost("revoke")]
    public IActionResult Revoke()
    {
        return Ok();
    }

    [HttpPost("introspect")]
    public IActionResult Introspect()
    {
        return Ok();
    }
}