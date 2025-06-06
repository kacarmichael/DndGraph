﻿using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Auth.Infrastructure.Security;

namespace Dnd.Application.Auth.Models;

[Table("AuthUser", Schema = "public")]
public class AuthUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Username { get; set; }
    public string CurrentSalt { get; set; }
    public string PreviousSalt { get; set; }
    public string HashedPassword { get; set; }
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
        CurrentSalt = Convert.ToBase64String(Passwords.GenerateSalt());
        PreviousSalt = String.Empty;
        HashedPassword = Passwords.HashPassword(password, CurrentSalt);
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
        CurrentSalt = Convert.ToBase64String(Passwords.GenerateSalt());
        PreviousSalt = String.Empty;
        HashedPassword = Passwords.HashPassword(password, CurrentSalt);
        Role = role;
        Email = email;
        Created = new DateTime(2000, 1, 1).ToUniversalTime();
        Updated = new DateTime(2000, 1, 1).ToUniversalTime();
        LastLogin = new DateTime(2000, 1, 1).ToUniversalTime();
        Locked = false;
        FailedLogins = 0;
        PasswordResetToken = "Not Implemented Yet";
    }

    public AuthUser(int id, string username, string salt, string hashedPassword, string role, string email)
    {
        Id = id;
        Username = username;
        CurrentSalt = salt;
        PreviousSalt = String.Empty;
        HashedPassword = hashedPassword;
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