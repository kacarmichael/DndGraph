using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _context;

    public CharacterRepository(CharacterDbContext context)
    {
        _context = context;
    }
    
    public void AddCharacter(Character character) => _context.Characters.Add(character);
    
    public IEnumerable<Character> GetAllCharacters() => _context.Characters;
    
    public Character GetCharacter(int id) => _context.Characters.FirstOrDefault(x => x.Id == id);
    
    public void DeleteCharacter(int id) => _context.Characters.Remove(GetCharacter(id));
    
    public void UpdateCharacter(Character character) => _context.Characters.Update(character);
    
    
}