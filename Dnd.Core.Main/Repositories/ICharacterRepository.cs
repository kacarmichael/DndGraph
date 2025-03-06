using Dnd.Core.Main.Models.Characters;

namespace Dnd.Core.Main.Repositories;

public interface ICharacterRepository
{
    Task<ICharacter> GetCharacterAsync(int characterId);

    Task<IEnumerable<ICharacter>> GetAllCharactersAsync();
    Task<ICharacter> AddCharacter(ICharacter character);
    void UpdateCharacter(ICharacter character);
    Task<Task> DeleteCharacterAsync(int id);
}