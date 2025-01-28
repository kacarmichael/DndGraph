using Dnd.API.Infrastructure;
using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Models.Characters.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _context;

    public CharacterRepository(CharacterDbContext context)
    {
        _context = context;
    }

    public async Task<ICharacter> AddCharacter(ICharacter character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
        return character;
    }

    public async Task<IEnumerable<ICharacter>> GetAllCharactersAsync() => await _context.Characters.ToListAsync();


    public async Task<ICharacter> GetCharacterAsync(int characterId)
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

    public void UpdateCharacter(ICharacter character) => _context.Characters.Update(character);
}