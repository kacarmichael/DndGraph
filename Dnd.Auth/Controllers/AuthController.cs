using Dnd.Auth.DTOs;
using Dnd.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.Auth.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IAuthService _authService;
    private readonly IJwtService _jwtService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService, IJwtService jwtService)
    {
        _logger = logger;
        _authService = authService;
        _jwtService = jwtService;
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
            resp.Token = _jwtService.GenerateToken(resp.Username, "User");
            return Ok(resp);
        }

        resp.IsSuccess = false;
        resp.Username = req.Username;
        resp.Token = "";
        return Unauthorized(resp);
    }

    [HttpPost("/register")]
    public async Task<ActionResult<RegisterResponseDto>> RegisterAsync([FromBody] RegisterRequestDto req)
    {
        _authService.AddUserAsync(req.Username, req.Password);
        return Ok(new RegisterResponseDto());
    }
}