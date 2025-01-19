using Dnd.Roll.API.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Infrastructure;

public class CharacterDbContext : DbContext
{
    public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options) { }
    
    public DbSet<Character> Characters { get; set; }
    
}