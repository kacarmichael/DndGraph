using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Models.Characters.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Infrastructure;

public class CharacterDbContext : DbContext
{
    public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options)
    {
    }

    public DbSet<ICharacter> Characters { get; set; }
}