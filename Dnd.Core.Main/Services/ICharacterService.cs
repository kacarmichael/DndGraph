using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Utils;

namespace Dnd.Core.Main.Services;

public interface ICharacterService
{
    Task<IEnumerable<IDto>> GetAllCharactersAsync();
    IEnumerable<ICharacter> GetCurrentCharacters();
    Task<IDto> GetCharacterAsync(int id);
    IClass GetClassUsed(string className);
    Task<ICharacter> AddCharacterAsync(ICharacter character);
    IEnumerable<IClass> GetAllClasses();
}