using Dnd.Application.Auth.Models;

namespace Dnd.API.Auth.DTOs;

public class RegisterResponseDto
{
    public string Username { get; set; }
    public string Email { get; set; }

    public RegisterResponseDto(AuthUser user)
    {
        Username = user.Username;
        Email = user.Email;
    }
}