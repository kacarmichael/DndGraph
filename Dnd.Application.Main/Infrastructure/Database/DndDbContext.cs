using Dnd.Application.Main.Infrastructure.EntityConfigurations;
using Dnd.Application.Main.Models.Campaigns;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Application.Main.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dnd.Application.Main.Infrastructure;

public class DndDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DndDbContext(DbContextOptions<DndDbContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new CharacterEntityConfiguration())
            // .ApplyConfiguration(new CharacterStatsEntityConfiguration())
            .ApplyConfiguration(new CharacterClassEntityConfiguration())
            .ApplyConfiguration(new UserCharacterCampaignEntityConfiguration());
        // .ApplyConfiguration(new UserEntityConfiguration());

        builder.Entity<DiceRollBase>()
            //.HasBaseType<IDiceRoll>()
            .HasDiscriminator<string>("RollType")
            .HasValue<AbilityCheckRoll>("abilityCheck")
            .HasValue<SavingThrowRoll>("savingThrow")
            .HasValue<MeleeAttackRoll>("attackRollMelee")
            .HasValue<RangedAttackRoll>("attackRollRanged")
            .HasValue<DamageRoll>("damageRoll")
            .HasValue<SpellAttackRoll>("spellAttackRoll");

        builder.Entity<Class>().HasData(
            Models.Characters.Classes.AllClasses.Select(x => x)
        );

        //builder.Entity<CharacterClass>


        // builder.Entity<Character>().HasData(
        //     new Character(
        //         id: 1,
        //         name: "Test Character",
        //         level: 1,
        //         ac: 10,
        //         charClass: new Dictionary<String, int>(),
        //         stats: new CharacterStats(
        //             level: 1,
        //             abilities: new AbilityBlock(
        //                 new List<IAbility>()
        //                 {
        //                     new Ability("Strength", 10, true),
        //                     new Ability("Dexterity", 10, true),
        //                     new Ability("Constitution", 10, true),
        //                     new Ability("Intelligence", 10, true),
        //                     new Ability("Wisdom", 10, true),
        //                     new Ability("Charisma", 10, true)
        //                 }
        //             ),
        //             skills: new SkillBlock(
        //                 new List<ISkill>()
        //                 {
        //                     new Skill("Acrobatics", 10, true),
        //                     new Skill("Animal Handling", 10, true),
        //                     new Skill("Arcana", 10, true),
        //                     new Skill("Athletics", 10, true),
        //                     new Skill("Deception", 10, true),
        //                     new Skill("History", 10, true),
        //                     new Skill("Insight", 10, true),
        //                     new Skill("Intimidation", 10, true),
        //                     new Skill("Investigation", 10, true),
        //                     new Skill("Medicine", 10, true),
        //                     new Skill("Nature", 10, true),
        //                     new Skill("Perception", 10, true),
        //                     new Skill("Performance", 10, true),
        //                     new Skill("Persuasion", 10, true),
        //                     new Skill("Religion", 10, true),
        //                     new Skill("Sleight of Hand", 10, true),
        //                     new Skill("Stealth", 10, true),
        //                     new Skill("Survival", 10, true)
        //                 }
        //             )
        //         )
        //     )
        //);
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterStats> CharacterStats { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<CampaignSession> CampaignSessions { get; set; }
    public DbSet<DomainUser> Users { get; set; }
    public DbSet<DiceRollBase> Rolls { get; set; }
}