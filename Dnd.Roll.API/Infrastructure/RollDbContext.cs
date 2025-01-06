using Dnd.Roll.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Infrastructure;

public class RollDbContext : DbContext
{
    public RollDbContext(DbContextOptions<RollDbContext> options) : base(options)
    {
    }

    public DbSet<DiceRoll> Rolls { get; set; } = null!;
}