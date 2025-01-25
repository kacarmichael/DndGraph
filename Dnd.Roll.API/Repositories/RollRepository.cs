using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Rolls;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Repositories;

public class RollRepository : IRollRepository
{
    private readonly RollDbContext _rollDbContext;
    private readonly ICharacterRepository _characterRepository;

    public RollRepository(RollDbContext rollDbContext, ICharacterRepository characterRepository)
    {
        _rollDbContext = rollDbContext;
        _characterRepository = characterRepository;
    }

    public async Task<DiceRollBase> GetRollById(int id)
    {
        return await _rollDbContext.Rolls.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
    }

    public async Task AddRoll(DiceRollBase roll)
    {
        _rollDbContext.Rolls.Add(roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task AddRollAsync(DiceRollBase roll)
    {
        _rollDbContext.Rolls.Add(roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task UpdateRoll(DiceRollBase roll)
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