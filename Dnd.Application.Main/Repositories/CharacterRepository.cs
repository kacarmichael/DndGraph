using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories;

public class CharacterRepository<TCharacter> : ICharacterRepository
    where TCharacter : class, ICharacter
{
    private readonly CharacterDbContext _context;
    //private readonly Type _concreteType;

    public CharacterRepository(CharacterDbContext context)
    {
        _context = context;
        //_concreteType = typeof(TCharacter);
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
}