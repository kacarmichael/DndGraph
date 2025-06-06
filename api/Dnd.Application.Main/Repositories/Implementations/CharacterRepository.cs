﻿using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Infrastructure.Database;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories.Implementations;

public class CharacterRepository : ICharacterRepository<Character, CharacterStats, CharacterClass>
{
    private readonly DndDbContext _context;

    public CharacterRepository(DndDbContext context)
    {
        _context = context;
    }

    public async Task<Character> AddCharacterAsync(Character character)
    {
        _context.Characters.Add((Character)character);
        await _context.SaveChangesAsync();
        return character;
    }

    // public async Task<Character> AddCharacterAsync(Character character, ICharacterStats stats,
    //     IEnumerable<ICharacterClass> classes)
    // {
    //     ////////This should be redundant???//////
    //     // _context.Characters.Add((Character)character);
    //     // await _context.SaveChangesAsync();
    //
    //     _context.CharacterClasses.AddRangeAsync(classes.Select(cc => (CharacterClass)cc));
    //     return classes;
    // }

    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        return await _context.Characters.ToListAsync();
    }
        


    public async Task<Character> GetCharacterAsync(int characterId)
    {
        return await _context.Characters.FirstOrDefaultAsync(x => x.Id == characterId);
    }

    public async Task<Task> DeleteCharacterAsync(int id)
    {
        var c = await GetCharacterAsync(id);
        if (c != null)
        {
            _context.Characters.Remove(c);
            await _context.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }

    public Task<Character> UpdateCharacterAsync(Character character)
    {
        return Task.FromResult(_context.Characters.Update(character).Entity);
    }

    public async Task<CharacterStats> AddStatBlock(CharacterStats stats)
    {
        _context.CharacterStats.Add(stats);
        await _context.SaveChangesAsync();
        return stats;
    }

    public async Task<IEnumerable<CharacterStats>> GetAllStatBlocksAsync()
    {
        return await _context.CharacterStats.ToListAsync();
    }

    public async Task<CharacterStats> GetStatBlockByIdAsync(int id)
    {
        return await _context.CharacterStats.FirstOrDefaultAsync(cs => cs.CharacterId == id);
    }

    public void UpdateCharacterStats(CharacterStats stats) => _context.CharacterStats.Update(stats);

    public async Task<Task> DeleteStatBlockByIdAsync(int id)
    {
        var cs = await GetStatBlockByIdAsync(id);
        if (cs != null)
        {
            _context.CharacterStats.Remove(cs);
            await _context.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<CharacterClass>> AddCharacterClassesAsync(IEnumerable<CharacterClass> classes)
    {
        var conv = classes.Select(cc => cc);
        await _context.CharacterClasses.AddRangeAsync(conv);
        await _context.SaveChangesAsync();
        return classes;
    }

    public async Task<IEnumerable<CharacterClass>> GetAllCharacterClassesAsync()
    {
        return await _context.CharacterClasses.ToListAsync();
    }

    public async Task<IEnumerable<CharacterClass>> GetCharacterClassesByIdAsync(int id)
    {
        return await _context.CharacterClasses.Where(cc => cc.CharacterId == id).ToListAsync();
    }

    public void UpdateCharacterClass(CharacterClass cc) => _context.CharacterClasses.Update(cc);

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