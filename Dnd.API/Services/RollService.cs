using Dnd.API.DTOs;
using Dnd.API.Models.Dice;
using Dnd.API.Models.Dice.Implementations;
using Dnd.API.Models.Dice.Interfaces;
using Dnd.API.Models.Rolls.Interfaces;
using Dnd.API.Repositories;

namespace Dnd.API.Services;

public class RollService : IRollService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IRollRepository _rollRepository;
    private readonly IRollMapperService _rollMapperService;
    private readonly IDiceSimulationFactory _diceSimulationFactory;

    public RollService(ICharacterRepository characterRepository, IRollRepository rollRepository,
        IRollMapperService rollMapperService, IDiceSimulationFactory diceSimulationFactory)
    {
        _characterRepository = characterRepository;
        _rollRepository = rollRepository;
        _rollMapperService = rollMapperService;
        _diceSimulationFactory = diceSimulationFactory;
    }

    public async Task<RollResponseDto> Roll(RollRequestDto req)
    {
        var character = await _characterRepository.GetCharacterAsync((int)req.CharacterId);
        var roll = await _rollMapperService.Map(req);
        await _rollRepository.AddRollAsync(roll);
        var resp = _rollMapperService.Map(roll);
        return resp;
    }

    public Task<IDiceSimulation> Simulate(IDiceSet set, int trials)
    {
        return Task.FromResult(_diceSimulationFactory.CreateSimulation(set, trials));
    }
}