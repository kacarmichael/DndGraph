namespace Dnd.Auth.Models.Interfaces;

public interface IAuthUser
{
    string Username { get; set; }
    string Password { get; set; }
    string Email { get; set; }
    string Role { get; set; }
    DateTime Created { get; set; }
    DateTime Updated { get; set; }
    DateTime LastLogin { get; set; }
    int FailedLogins { get; set; }
    bool Locked { get; set; }
    string PasswordResetToken { get; set; }
}