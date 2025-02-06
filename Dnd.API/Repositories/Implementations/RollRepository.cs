using Dnd.API.Infrastructure;
using Dnd.API.Models.Rolls.Implementations;
using Dnd.API.Models.Rolls.Interfaces;
using Dnd.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.API.Repositories.Implementations;

public class RollRepository<TRoll> : IRollRepository
    where TRoll : class, IDiceRoll
{
    private readonly RollDbContext _rollDbContext;
    private readonly ICharacterRepository _characterRepository;
    private readonly Type _concreteType;

    public RollRepository(RollDbContext rollDbContext, ICharacterRepository characterRepository)
    {
        _rollDbContext = rollDbContext;
        _characterRepository = characterRepository;
        _concreteType = typeof(TRoll);
    }

    public async Task<IDiceRoll> GetRollById(int id)
    {
        return await _rollDbContext.Rolls.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
    }

    public async Task AddRoll(IDiceRoll roll)
    {
        _rollDbContext.Rolls.Add((DiceRollBase)roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task AddRollAsync(IDiceRoll roll)
    {
        _rollDbContext.Rolls.Add((DiceRollBase)roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task UpdateRoll(IDiceRoll roll)
    {
        _rollDbContext.Rolls.Update((DiceRollBase)roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task DeleteRoll(int id)
    {
        var roll = await GetRollById(id);
        if (roll != null)
        {
            _rollDbContext.Rolls.Remove((DiceRollBase)roll);
            await _rollDbContext.SaveChangesAsync();
        }
    }
}