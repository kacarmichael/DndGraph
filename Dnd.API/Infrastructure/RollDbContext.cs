using Dnd.API.Models.Rolls;
using Dnd.API.Models.Rolls.Implementations;
using Dnd.API.Models.Rolls.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Infrastructure;

public class RollDbContext : DbContext
{
    public RollDbContext(DbContextOptions<RollDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IDiceRoll>()
            .HasDiscriminator<string>("RollType")
            .HasValue<AbilityCheckRoll>("abilityCheck")
            .HasValue<SavingThrowRoll>("savingThrow")
            .HasValue<MeleeAttackRoll>("attackRollMelee")
            .HasValue<RangedAttackRoll>("attackRollRanged")
            .HasValue<DamageRoll>("damageRoll")
            .HasValue<SpellAttackRoll>("spellAttackRoll");
    }

    public DbSet<IDiceRoll> Rolls { get; set; }
}