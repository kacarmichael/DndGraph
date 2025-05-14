using Dnd.Application.Main.Infrastructure;
using Dnd.Application.Main.Infrastructure.Database;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Application.Main.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Application.Main.Repositories.Implementations;

public class RollRepository : IRollRepository<DiceRollBase>
{
    private readonly DndDbContext _rollDbContext;
    private readonly ICharacterRepository<Character, CharacterStats, CharacterClass> _characterRepository;
    private readonly Type _concreteType;

    public RollRepository(DndDbContext rollDbContext,
        ICharacterRepository<Character, CharacterStats, CharacterClass> characterRepository)
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
        _rollDbContext.Rolls.Add((DiceRollBase)roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task AddRollAsync(DiceRollBase roll)
    {
        _rollDbContext.Rolls.Add((DiceRollBase)roll);
        await _rollDbContext.SaveChangesAsync();
    }

    public async Task UpdateRoll(DiceRollBase roll)
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