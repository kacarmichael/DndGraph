using Dnd.Auth.Services.Interfaces;

namespace Dnd.Auth.Services.Implementations;

public class AuthService : IAuthService
{
    public IJwtService Generator { get; set; }

    public AuthService(IJwtService generator)
    {
        Generator = generator;
    }
}