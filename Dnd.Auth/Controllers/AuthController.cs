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
        // var requestBody = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        // _logger.LogInformation($"Request Body: {requestBody}");
        if (req.Username == "admin" && req.Password == "asdf")
        {
            return Ok(
                new LoginResponseDto(
                    username: req.Username,
                    success: true,
                    token: _jwtService.GenerateToken(req.Username, "User")));
        }
        
        return Unauthorized(
            new LoginResponseDto(
                    username: req.Username,
                    success: false,
                    token: ""));
    }

    [HttpPost("/register")]
    public async Task<ActionResult<RegisterResponseDto>> RegisterAsync([FromBody] RegisterRequestDto req)
    {
        await _authService.AddUserAsync(req.DtoToUser());
        return Ok(new RegisterResponseDto(req.DtoToUser()));
    }
    
    [HttpPost("/reset-password")]
    public async Task<ActionResult<PasswordResetResponseDto>> ResetPasswordAsync([FromBody] PasswordResetRequestDto req)
    {
        return Ok(new PasswordResetResponseDto());
    }
}