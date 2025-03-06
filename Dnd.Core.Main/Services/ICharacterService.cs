using Dnd.Core.Main.Models.Characters;

namespace Dnd.Core.Main.Services;

public interface ICharacterService
{
    Task<IEnumerable<ICharacter>> GetAllCharactersAsync();
    IEnumerable<ICharacter> GetCurrentCharacters();
    Task<ICharacter> GetCharacterAsync(int id);
    IClass GetClassUsed(string className);
    Task<ICharacter> AddCharacterAsync(ICharacter character);
    IEnumerable<IClass> GetAllClasses();
}