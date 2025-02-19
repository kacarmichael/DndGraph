namespace Dnd.Auth.DTOs;

public class LoginResponseDto
{
    public bool IsSuccess { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }

    public LoginResponseDto(bool success, string username, string token)
    {
        IsSuccess = success;
        Username = username;
        Token = token;
    }

    public LoginResponseDto()
    {
    }
}