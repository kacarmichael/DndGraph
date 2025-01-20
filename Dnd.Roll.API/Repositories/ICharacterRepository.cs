using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Repositories;

public interface ICharacterRepository
{
    IEnumerable<Character> GetAllCharacters();
    Character GetCharacter(int id);
    void AddCharacter(Character character);
    void UpdateCharacter(Character character);
    void DeleteCharacter(int id);
}