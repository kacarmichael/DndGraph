using Dnd.Application.Main.DTOs;
using Dnd.Core.Main.Models.Dice;
using Dnd.Core.Main.Models.Rolls;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.Services;

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

    public async Task<DtoBase> Roll(DtoBase request)
    {
        if (request is RollRequestDto req)
        {
            var character = await _characterRepository.GetCharacterAsync((int)req.CharacterId);
            var roll = await _rollMapperService.Map(req);
            await _rollRepository.AddRollAsync(roll);
            var resp = _rollMapperService.Map(roll);
            return resp;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public Task<IDiceSimulation> Simulate(IDiceSet set, int trials)
    {
        return Task.FromResult(_diceSimulationFactory.CreateSimulation(set, trials, 0));
    }

    public DtoBase Simulate(DtoBase request)
    {
        if (request is DiceSimulationRequestDto req)
        {
            return new DiceSimulationResponseDto(
                _diceSimulationFactory.CreateSimulation(
                    req.ToDiceSet(),
                    req.Trials,
                    req.Modifier
                ));
        }
        else
        {
            throw new ArgumentException();
        }

        ;
    }

    public DtoBase DiceRoll(DtoBase request)
    {
        if (request is DiceRollRequestDto req)
        {
            return new DiceRollResponseDto(
                d4: req.D4,
                d6: req.D6,
                d8: req.D8,
                d10: req.D10,
                d12: req.D12,
                d20: req.D20,
                d100: req.D100,
                modifier: req.Modifier,
                total: req.ToDiceSet().Roll());
        }

        throw new ArgumentException();
    }
}