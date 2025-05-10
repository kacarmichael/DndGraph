using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.Services.Interfaces;

public interface ICharacterService
{
    Task<IEnumerable<Character>> GetAllCharactersAsync();
    IEnumerable<Character> GetCurrentCharacters();
    Task<Character> GetCharacterAsync(int id);
    Class GetClassUsed(string className);
    Task<Character> AddCharacterAsync(Character character);
    IEnumerable<Class> GetAllClasses();
    Task<IEnumerable<CharacterStats>> GetAllStatBlocksAsync();
    Task<CharacterStats> GetStatBlockByIdAsync(int id);
    Task<CharacterStats> AddStatBlockAsync(CharacterStats stats);
    Task<IEnumerable<CharacterClass>> GetAllCharacterClasses();
    Task<IEnumerable<CharacterClass>> GetCharacterClassesByIdAsync(int id);
    Task<IEnumerable<CharacterClass>> AddCharacterClassesAsync(IEnumerable<CharacterClass> classes);
    Character DtoToCharacter(IDto req);
    CharacterStats DtoToCharacterStats(IDto req, int characterId);
    IEnumerable<CharacterClass> DtoToCharacterClasses(IDto req, int characterId);
}