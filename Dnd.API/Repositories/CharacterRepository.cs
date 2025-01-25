using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _context;

    public CharacterRepository(CharacterDbContext context)
    {
        _context = context;
    }

    public async void AddCharacter(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Character>> GetAllCharactersAsync() => await _context.Characters.ToListAsync();


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

    public void UpdateCharacter(Character character) => _context.Characters.Update(character);
}