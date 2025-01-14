using System.Text.Json;
using Dnd.Roll.API.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Infrastructure;

public class CharacterDbContext : DbContext
{
    public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options) { }
    
    public DbSet<Character> Characters { get; set; }

    // public void Populate()
    // {
    //     string jsonFile = "characters.json";
    //     
    //     using (StreamReader reader = new StreamReader(jsonFile))
    //     {
    //         string json = reader.ReadToEnd();
    //         List<Character> characters = JsonSerializer.Deserialize<List<Character>>(json);
    //
    //         foreach (Character character in characters)
    //         {
    //             Character existingCharacter = Characters.FirstOrDefault(c => c.Id == character.Id);
    //
    //             if (existingCharacter == null)
    //             {
    //                 Characters.Add(character);
    //             }
    //         }
    //         
    //         SaveChanges();
    //     }
    //     
    // }
    //
}