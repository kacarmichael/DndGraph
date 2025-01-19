using Dnd.Roll.API.Models.Rolls;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Infrastructure;

public class RollDbContext : DbContext
{
    public RollDbContext(DbContextOptions<RollDbContext> options) : base(options)
    {
    }

    public DbSet<DiceRollBase> Rolls { get; set; }
}