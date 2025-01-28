using Dnd.API.Infrastructure;
using Dnd.API.Models.Rolls;
using Dnd.API.Models.Rolls.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Repositories;

public class RollRepository : IRollRepository
{
    private readonly RollDbContext _rollDbContext;
    private readonly ICharacterRepository _characterRepository;

    public RollRepository(RollDbContext rollDbContext, ICharacterRepository characterRepository)
    {
        _rollDbContext = rollDbContext;
        _characterRepository = characterRepository;
    }

    public async Task<IDiceRoll> GetRollById(int id)
    {
        return await _rollDbContext.Rolls.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
    }

    public async Task AddRoll(IDiceRoll roll)
    {
        _rollDbContext.Rolls.Add(roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task AddRollAsync(IDiceRoll roll)
    {
        _rollDbContext.Rolls.Add(roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task UpdateRoll(IDiceRoll roll)
    {
        _rollDbContext.Rolls.Update(roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task DeleteRoll(int id)
    {
        var roll = await GetRollById(id);
        if (roll != null)
        {
            _rollDbContext.Rolls.Remove(roll);
            await _rollDbContext.SaveChangesAsync();
        }
    }
}