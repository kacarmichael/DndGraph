using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Services;

public interface ICharacterService
{
    IEnumerable<Character> GetAllCharacters();
    IEnumerable<Character> GetCurrentCharacters();
    Character GetCharacterById(int id);
    Class GetClassUsed(string className);
}