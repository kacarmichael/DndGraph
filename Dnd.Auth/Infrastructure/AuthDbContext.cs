using Dnd.Auth.Models.Implementations;
using Dnd.Auth.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Auth.Infrastructure;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    public DbSet<IAuthUser> Users;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AuthUser>().HasData(
            new AuthUser(username: "admin", password: "asdf")
        );
    }
}