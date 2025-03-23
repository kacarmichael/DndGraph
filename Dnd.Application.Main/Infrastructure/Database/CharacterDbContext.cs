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
        builder.Entity<Character>().HasData(
            new Character(
                id: 1,
                name: "Test Character",
                level: 1,
                ac: 10,
                charClass: new Dictionary<String, int>(),
                stats: new CharacterStats(
                    arcana: 10,
                    athletics: 10,
                    deception: 10,
                    history: 10,
                    insight: 10,
                    intimidation: 10,
                    investigation: 10,
                    medicine: 10,
                    nature: 10,
                    perception: 10,
                    religion: 10,
                    stealth: 10,
                    survival: 10,
                    acrobatics: 10,
                    animalHandling: 10,
                    strength: 10,
                    dexterity: 10,
                    constitution: 10,
                    intelligence: 10,
                    wisdom: 10,
                    charisma: 10,
                    sleightOfHand: 10,
                    performance: 10,
                    persuasion: 10,
                    proficiencies: new List<string>()
                )
            )
        );
    }

    public DbSet<Character> Characters { get; set; }
}