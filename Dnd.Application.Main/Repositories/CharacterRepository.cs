using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Intermediate;
using Dnd.Core.Main.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly DndDbContext _context;

    public CharacterRepository(DndDbContext context)
    {
        _context = context;
    }

    public async Task<ICharacter> AddCharacter(ICharacter character)
    {
        _context.Characters.Add((Character)character);
        await _context.SaveChangesAsync();
        return character;
    }

    public async Task<IEnumerable<ICharacter>> GetAllCharactersAsync() =>
        await _context.Characters.ToListAsync();


    public async Task<ICharacter> GetCharacterAsync(int characterId)
    {
        return await _context.Characters.FirstOrDefaultAsync(x => x.Id == characterId);
    }

    public async Task<Task> DeleteCharacterAsync(int id)
    {
        var c = await GetCharacterAsync(id);
        if (c != null)
        {
            _context.Characters.Remove((Character)c);
            await _context.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }

    public void UpdateCharacter(ICharacter character) => _context.Characters.Update((Character)character);

    public async Task<ICharacterStats> AddStatBlock(ICharacterStats stats)
    {
        _context.CharacterStats.Add((CharacterStats)stats);
        await _context.SaveChangesAsync();
        return stats;
    }

    public async Task<IEnumerable<ICharacterStats>> GetAllStatBlocksAsync()
    {
        return await _context.CharacterStats.ToListAsync();
    }

    public async Task<ICharacterStats> GetStatBlockByIdAsync(int id)
    {
        return await _context.CharacterStats.FirstOrDefaultAsync(cs => cs.CharacterId == id);
    }

    public void UpdateCharacterStats(ICharacterStats stats) => _context.CharacterStats.Update((CharacterStats)stats);

    public async Task<Task> DeleteStatBlockByIdAsync(int id)
    {
        var cs = await GetStatBlockByIdAsync(id);
        if (cs != null)
        {
            _context.CharacterStats.Remove((CharacterStats)cs);
            await _context.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }

    public async Task<ICharacterClass> AddCharacterClass(ICharacterClass cc)
    {
        _context.CharacterClasses.Add((CharacterClass)cc);
        await _context.SaveChangesAsync();
        return cc;
    }

    public async Task<IEnumerable<ICharacterClass>> GetAllCharacterClassesAsync()
    {
        return await _context.CharacterClasses.ToListAsync();
    }

    public async Task<IEnumerable<ICharacterClass>> GetCharacterClassesByIdAsync(int id)
    {
        return await _context.CharacterClasses.Where(cc => cc.CharacterId == id).ToListAsync();
    }

    public void UpdateCharacterClass(ICharacterClass cc) => _context.CharacterClasses.Update((CharacterClass)cc);

    public async Task<Task> DeleteCharacterClassesByIdAsync(int id)
    {
        var cs = await GetCharacterClassesByIdAsync(id);
        if (cs != null)
        {
            _context.CharacterStats.Remove((CharacterStats)cs);
            await _context.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }
}