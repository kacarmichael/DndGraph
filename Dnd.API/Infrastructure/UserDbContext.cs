using Dnd.API.Models.Users.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<DomainUser> Users { get; set; }
}