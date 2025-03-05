using System.Text.Json;

namespace Dnd.Auth.DTOs;

public class LoginRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginRequestDto()
    {
    }

    public LoginRequestDto(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}