using Microsoft.AspNetCore.Mvc;

namespace Dnd.Auth.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    public AuthController()
    {
    }

    [HttpGet("/login")]
    public static void LoginAsync()
    {
    }
}