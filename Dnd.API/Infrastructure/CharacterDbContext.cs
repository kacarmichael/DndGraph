using Dnd.API.Models.Characters.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Infrastructure;

public class CharacterDbContext : DbContext
{
    public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Character>().HasBaseType<ICharacter>();
    // }

    public DbSet<Character> Characters { get; set; }
}