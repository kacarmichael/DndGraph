using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Services;

public interface ICharacterService
{
    Task<IEnumerable<Character>> GetAllCharactersAsync();
    IEnumerable<Character> GetCurrentCharacters();
    Task<Character> GetCharacterAsync(int id);
    Class GetClassUsed(string className);
    Task<Character> AddCharacterAsync(Character character);
}