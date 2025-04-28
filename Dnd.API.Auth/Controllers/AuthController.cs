using Dnd.API.Auth.DTOs;
using Dnd.Application.Auth.Extensions;
using Dnd.Application.Auth.Infrastructure.Security;
using Dnd.Application.Auth.Models;
using Dnd.Application.Auth.Services.Interfaces;
using Dnd.Application.Logging.Interfaces;
using Dnd.Application.Main.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Auth.Controllers;

[AllowAnonymous]
[ApiController]
public class AuthController : ControllerBase
{
    //private readonly ILogger _logger;
    private readonly IAuthService _authService;
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;
    //private readonly IUserMapperService _userMapperService;
    private readonly ILoggingClient _logger;

    public AuthController(ILoggingClient logger, IAuthService authService, IJwtService jwtService,
        IUserService userService)
    {
        _logger = logger;
        _authService = authService;
        _jwtService = jwtService;
        _userService = userService;
        //_userMapperService = userMapperService;
        _logger.LogInformation("Auth controller created");
    }

    [HttpPost("/login")]
    public async Task<ActionResult<LoginResponseDto>> LoginAsync([FromBody] LoginRequestDto req)
    {
        AuthUser user = await _authService.GetUserAsync(req.Username);
        if (user == null || user.HashedPassword != Passwords.HashPassword(req.Password, user.CurrentSalt))
        {
            return Unauthorized(
                new LoginResponseDto(
                    username: req.Username,
                    success: false,
                    token: ""));
        }

        // var requestBody = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        _logger.LogInformation($"Request: {req}");
        //Console.WriteLine("Console logging test");
        return Ok(
            new LoginResponseDto(
                username: req.Username,
                success: true,
                token: _jwtService.GenerateToken(req.Username, "User")));
    }

    [HttpPost("/register")]
    public async Task<ActionResult<RegisterResponseDto>> RegisterAsync([FromBody] RegisterRequestDto req)
    {
        await _authService.AddUserAsync(req.DtoToUser());
        await _userService.AddUserAsync(DomainUserExtensions.FromAuthUser(req.DtoToUser()));
        return Ok(new RegisterResponseDto(req.DtoToUser()));
    }

    [HttpPost("/reset-password")]
    public async Task<ActionResult<PasswordResetResponseDto>> ResetPasswordAsync([FromBody] PasswordResetRequestDto req)
    {
        return Ok(new PasswordResetResponseDto());
    }
}