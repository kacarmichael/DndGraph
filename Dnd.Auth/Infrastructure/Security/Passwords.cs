using System.Security.Cryptography;

namespace Dnd.Auth.Infrastructure.Security;

public static class Passwords
{
    public static byte[] GenerateSalt() => RandomNumberGenerator.GetBytes(16);

    public static string HashPassword(string password)
    {
        byte[] salt = GenerateSalt();
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string saltedPassword = password + Convert.ToBase64String(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(saltedPassword, salt, 1000000))
        {
            byte[] hashedPassword = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hashedPassword);
        }
    }

    public static string HashPassword(string password, string salt)
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(Convert.FromBase64String(salt));
        }

        string saltedPassword = password + salt;

        using (var pbkdf2 = new Rfc2898DeriveBytes(saltedPassword, Convert.FromBase64String(salt), 1000000))
        {
            byte[] hashedPassword = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hashedPassword);
        }
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        string[] parts = storedHash.Split(':');
        byte[] salt = Convert.FromBase64String(parts[0]);

        string saltedPassword = Convert.ToBase64String(salt) + password;

        using (var pbkdf2 = new Rfc2898DeriveBytes(saltedPassword, salt, 1000000))
        {
            byte[] hashedPassword = pbkdf2.GetBytes(32);
            return hashedPassword.SequenceEqual(Convert.FromBase64String(parts[1]));
        }
    }
}