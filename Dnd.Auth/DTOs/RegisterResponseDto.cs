using Dnd.Auth.Models.Interfaces;

namespace Dnd.Auth.DTOs;

public class RegisterResponseDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public RegisterResponseDto(IAuthUser user)
    {
        Username = user.Username;
        Email = user.Email;
    }
}