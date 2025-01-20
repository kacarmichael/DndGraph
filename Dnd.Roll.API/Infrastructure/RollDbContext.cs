using Dnd.Roll.API.Models.Rolls;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Infrastructure;

public class RollDbContext : DbContext
{
    public RollDbContext(DbContextOptions<RollDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiceRollBase>()
            .HasDiscriminator<string>("RollType")
            .HasValue<AbilityCheckRoll>("abilityCheck")
            .HasValue<SavingThrowRoll>("savingThrow")
            .HasValue<MeleeAttackRoll>("attackRollMelee")
            .HasValue<RangedAttackRoll>("attackRollRanged")
            .HasValue<DamageRoll>("damageRoll")
            .HasValue<SpellAttackRoll>("spellAttackRoll");
    }

    public DbSet<DiceRollBase> Rolls { get; set; }
}