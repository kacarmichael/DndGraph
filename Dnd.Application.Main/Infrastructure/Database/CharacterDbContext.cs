using Dnd.Application.Main.Infrastructure.EntityConfigurations;
using Dnd.Application.Main.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dnd.Application.Main.Infrastructure;

public class CharacterDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public CharacterDbContext(DbContextOptions<CharacterDbContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Character>().HasBaseType<ICharacter>();
    // }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CharacterEntityConfiguration());

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
}