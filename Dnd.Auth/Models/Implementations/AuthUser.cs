using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Auth.Models.Interfaces;

namespace Dnd.Auth.Models.Implementations;

[Table("AuthUser", Schema = "public")]
public class AuthUser : IAuthUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public DateTime LastLogin { get; set; }
    public bool Locked { get; set; }
    public int FailedLogins { get; set; }
    public string PasswordResetToken { get; set; }

    public AuthUser(string username, string password, string email, string role = "User")
    {
        Username = username;
        Password = password;
        Role = role;
        Email = email;
        Created = DateTime.UtcNow;
        Updated = DateTime.UtcNow;
        LastLogin = DateTime.UtcNow;
        Locked = false;
        FailedLogins = 0;
        PasswordResetToken = "Not Implemented Yet";
    }

    public AuthUser(int id, string username, string password, string email, string role = "User")
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        Email = email;
        Created = new DateTime(2000, 1, 1).ToUniversalTime();
        Updated = new DateTime(2000, 1, 1).ToUniversalTime();
        LastLogin = new DateTime(2000, 1, 1).ToUniversalTime();
        Locked = false;
        FailedLogins = 0;
        PasswordResetToken = "Not Implemented Yet";
    }

    public AuthUser()
    {
    }
}