using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Repositories.Interfaces;

public interface ICharacterRepository
{
    Task<ICharacter> GetCharacterAsync(int characterId);

    Task<IEnumerable<ICharacter>> GetAllCharactersAsync();
    Task<ICharacter> AddCharacter(ICharacter character);
    void UpdateCharacter(ICharacter character);
    Task<Task> DeleteCharacterAsync(int id);
}