namespace Dnd.Auth.Services.Interfaces;

public interface IAuthService
{
    IJwtService Generator { get; set; }
}