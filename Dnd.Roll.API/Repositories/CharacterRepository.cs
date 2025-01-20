using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _characterContext;

    public CharacterRepository(CharacterDbContext characterContext)
    {
        _characterContext = characterContext;
    }
    
    public async Task<Character> GetCharacterById(int id)
    {
        return await _characterContext.Characters.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
    }
}