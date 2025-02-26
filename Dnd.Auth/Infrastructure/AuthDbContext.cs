using Dnd.Auth.Models.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Auth.Infrastructure;

public class AuthDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AuthDbContext(DbContextOptions<AuthDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<AuthUser> AuthUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AuthUser>().HasData(
            new AuthUser(id: 1, username: "admin", password: "asdf", email: "test@localhost", role: "Admin")
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Postgres"));
    }
}