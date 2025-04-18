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
    ICharacter DtoToCharacter(IDto req);
    ICharacterStats DtoToCharacterStats(IDto req);
    IEnumerable<ICharacterClass> DtoToCharacterClasses(IDto req, int characterId);
}