using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Dice;
using Dnd.Roll.API.Repositories;

namespace Dnd.Roll.API.Services;

public class RollService : IRollService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IRollRepository _rollRepository;
    private readonly IRollMapperService _rollMapperService;

    public RollService(ICharacterRepository characterRepository, IRollRepository rollRepository,
        IRollMapperService rollMapperService)
    {
        _characterRepository = characterRepository;
        _rollRepository = rollRepository;
        _rollMapperService = rollMapperService;
    }

    public async Task<RollResponseDto> Roll(RollRequestDto req)
    {
        var character = await _characterRepository.GetCharacterAsync((int)req.CharacterId);
        var roll = await _rollMapperService.Map(req);
        await _rollRepository.AddRollAsync(roll);
        var resp = _rollMapperService.Map(roll);
        return resp;
    }

    public Task<DiceSimulation> Simulate(DiceSet set, int trials)
    {
        return Task.FromResult(new DiceSimulation(set, trials));
    }
}