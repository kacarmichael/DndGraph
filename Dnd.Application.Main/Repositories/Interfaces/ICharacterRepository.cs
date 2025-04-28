using Dnd.Application.Main.Models.Characters;

namespace Dnd.Application.Main.Repositories.Interfaces;

public interface ICharacterRepository<TCharacter, TStats, TClass>
{
    Task<TCharacter> GetCharacterAsync(int characterId);
    Task<IEnumerable<TCharacter>> GetAllCharactersAsync();

    Task<TCharacter> AddCharacterAsync(TCharacter character);

    //Task<ICharacter> AddCharacterAsync(ICharacter character, ICharacterStats stats, IEnumerable<ICharacterClass> classes);
    Task<Character> UpdateCharacterAsync(TCharacter character);
    Task<Task> DeleteCharacterAsync(int id);
    Task<TStats> GetStatBlockByIdAsync(int id);
    Task<IEnumerable<TStats>> GetAllStatBlocksAsync();
    Task<TStats> AddStatBlock(TStats stats);
    void UpdateCharacterStats(TStats stats);
    Task<Task> DeleteStatBlockByIdAsync(int id);
    Task<IEnumerable<TClass>> GetCharacterClassesByIdAsync(int id);
    Task<IEnumerable<TClass>> GetAllCharacterClassesAsync();
    Task<IEnumerable<TClass>> AddCharacterClassesAsync(IEnumerable<TClass> classes);
    void UpdateCharacterClass(TClass cls);
    Task<Task> DeleteCharacterClassesByIdAsync(int id);
}