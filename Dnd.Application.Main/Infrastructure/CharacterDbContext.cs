using Dnd.Application.Main.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Infrastructure;

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