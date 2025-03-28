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
                stats: new CharacterStats()
            )
        );
    }

    public DbSet<Character> Characters { get; set; }
}