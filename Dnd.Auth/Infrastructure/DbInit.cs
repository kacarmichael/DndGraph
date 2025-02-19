using Dnd.Auth.Models.Implementations;

namespace Dnd.Auth.Infrastructure;

public class DbInit
{
    public static void Initialize(AuthDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Users.Any())
        {
            var user = new AuthUser(username: "admin", password: "asdf");
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}