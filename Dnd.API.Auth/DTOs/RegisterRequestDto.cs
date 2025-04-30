using Dnd.Application.Auth.Models;

namespace Dnd.API.Auth.DTOs;

public class RegisterRequestDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "User";

    public AuthUser DtoToUser() => new AuthUser(Username, Password, Email, Role);
}