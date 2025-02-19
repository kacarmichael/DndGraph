using Dnd.Auth.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.Auth.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/login")]
    public async Task<ActionResult<LoginResponseDto>> LoginAsync([FromBody] LoginRequestDto req)
    {
        var requestBody = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        _logger.LogInformation($"Request Body: {requestBody}");
        var resp = new LoginResponseDto();
        if (req.Username == "admin" && req.Password == "asdf")
        {
            resp.Username = req.Username;
            resp.IsSuccess = true;
            resp.Token = "token";
            return Ok(resp);
        }

        resp.IsSuccess = false;
        resp.Username = req.Username;
        resp.Token = "";
        return Unauthorized(resp);
    }
}