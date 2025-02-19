using Dnd.Auth.Models.Interfaces;

namespace Dnd.Auth.Models.Implementations;

public class AuthUser : IAuthUser
{
    public string Username { get; set; }
    public string Password { get; set; }

    public AuthUser(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public AuthUser()
    {
    }
}