using Dnd.Application.Main.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<DomainUser> Users { get; set; }
}