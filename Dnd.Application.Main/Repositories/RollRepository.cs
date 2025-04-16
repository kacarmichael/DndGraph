using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Core.Main.Models.Rolls;
using Dnd.Core.Main.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories;

public class RollRepository<TRoll> : IRollRepository
    where TRoll : class, IDiceRoll
{
    private readonly DndDbContext _rollDbContext;
    private readonly ICharacterRepository _characterRepository;
    private readonly Type _concreteType;

    public RollRepository(DndDbContext rollDbContext, ICharacterRepository characterRepository)
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