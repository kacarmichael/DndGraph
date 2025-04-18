using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Intermediate;

namespace Dnd.Core.Main.Repositories;

public interface ICharacterRepository
{
    Task<ICharacter> GetCharacterAsync(int characterId);
    Task<IEnumerable<ICharacter>> GetAllCharactersAsync();
    Task<ICharacter> AddCharacter(ICharacter character);
    void UpdateCharacter(ICharacter character);
    Task<Task> DeleteCharacterAsync(int id);
    Task<ICharacterStats> GetStatBlockByIdAsync(int id);
    Task<IEnumerable<ICharacterStats>> GetAllStatBlocksAsync();
    Task<ICharacterStats> AddStatBlock(ICharacterStats stats);
    void UpdateCharacterStats(ICharacterStats stats);
    Task<Task> DeleteStatBlockByIdAsync(int id);
    Task<IEnumerable<ICharacterClass>> GetCharacterClassesByIdAsync(int id);
    Task<IEnumerable<ICharacterClass>> GetAllCharacterClassesAsync();
    Task<ICharacterClass> AddCharacterClass(ICharacterClass cls);
    void UpdateCharacterClass(ICharacterClass cls);
    Task<Task> DeleteCharacterClassesByIdAsync(int id);
}