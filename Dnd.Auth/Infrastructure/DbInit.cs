using Dnd.Auth.Models.Implementations;

namespace Dnd.Auth.Infrastructure;

public class DbInit
{
    public static void Initialize(IdentityDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Users.Any())
        {
            var user = new AuthUser();
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}