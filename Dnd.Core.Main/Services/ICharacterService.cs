using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Utils;

namespace Dnd.Core.Main.Services;

public interface ICharacterService
{
    Task<IEnumerable<ICharacter>> GetAllCharactersAsync();
    IEnumerable<ICharacter> GetCurrentCharacters();
    Task<ICharacter> GetCharacterAsync(int id);
    IClass GetClassUsed(string className);
    Task<ICharacter> AddCharacterAsync(ICharacter character);
    IEnumerable<IClass> GetAllClasses();
    Task<IEnumerable<ICharacterStats>> GetAllStatBlocksAsync();
    Task<ICharacterStats> GetStatBlockByIdAsync(int id);
    Task<ICharacterStats> AddStatBlockAsync(ICharacterStats stats);
    Task<IEnumerable<ICharacterClass>> GetAllCharacterClasses();
    Task<IEnumerable<ICharacterClass>> GetCharacterClassesByIdAsync(int id);
    Task<IEnumerable<ICharacterClass>> AddCharacterClassesAsync(IEnumerable<ICharacterClass> classes);
    ICharacter DtoToCharacter(IDto req);
    ICharacterStats DtoToCharacterStats(IDto req, int characterId);
    IEnumerable<ICharacterClass> DtoToCharacterClasses(IDto req, int characterId);
}