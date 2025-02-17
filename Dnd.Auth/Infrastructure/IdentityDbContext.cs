using Dnd.Auth.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Auth.Infrastructure;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext()
    {
    }

    public DbSet<IAuthUser> Users;
}