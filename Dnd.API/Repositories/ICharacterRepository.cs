using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Repositories;

public interface ICharacterRepository
{
    Task<Character> GetCharacterAsync(int characterId);

    Task<IEnumerable<Character>> GetAllCharactersAsync();
    void AddCharacter(Character character);
    void UpdateCharacter(Character character);
    Task<Task> DeleteCharacterAsync(int id);
}