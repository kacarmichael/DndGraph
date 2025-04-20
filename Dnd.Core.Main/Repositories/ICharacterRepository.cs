namespace Dnd.Core.Main.Repositories;

public interface ICharacterRepository<TCharacter, TStats, TClass>
{
    Task<TCharacter> GetCharacterAsync(int characterId);
    Task<IEnumerable<TCharacter>> GetAllCharactersAsync();

    Task<TCharacter> AddCharacterAsync(TCharacter character);

    //Task<ICharacter> AddCharacterAsync(ICharacter character, ICharacterStats stats, IEnumerable<ICharacterClass> classes);
    void UpdateCharacter(TCharacter character);
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