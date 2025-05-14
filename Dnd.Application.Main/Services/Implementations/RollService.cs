using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Models.Intermediate;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Application.Main.Models.Simulations;
using Dnd.Application.Main.Repositories.Interfaces;
using Dnd.Application.Main.Services.Interfaces;
using Dnd.Application.Main.Utils;
using Dnd.Core.Caching;

namespace Dnd.Application.Main.Services.Implementations;

public class RollService : IRollService
{
    private readonly ICharacterRepository<Character, CharacterStats, CharacterClass> _characterRepository;
    private readonly IRollRepository<DiceRollBase> _rollRepository;
    private readonly IRollMapperService _rollMapperService;
    private readonly IDiceSimulationFactory _diceSimulationFactory;
    private readonly IDiceRollCache _diceRollCache;
    private readonly IDiceSimulationCache _diceSimulationCache;

    public RollService(ICharacterRepository<Character, CharacterStats, CharacterClass> characterRepository,
        IRollRepository<DiceRollBase> rollRepository,
        IRollMapperService rollMapperService, IDiceSimulationFactory diceSimulationFactory,
        IDiceRollCache diceRollCache, IDiceSimulationCache diceSimulationCache)
    {
        _characterRepository = characterRepository;
        _rollRepository = rollRepository;
        _rollMapperService = rollMapperService;
        _diceSimulationFactory = diceSimulationFactory;
        _diceRollCache = diceRollCache;
        _diceSimulationCache = diceSimulationCache;
    }

    public async Task<IDto> Roll(IDto request)
    {
        if (request is RollRequestDto req)
        {
            var character = await _characterRepository.GetCharacterAsync((int)req.CharacterId);
            var roll = await _rollMapperService.Map(req);
            await _rollRepository.AddRollAsync(roll);
            //_diceRollCache.AddRoll(roll);
            var resp = _rollMapperService.Map(roll);
            return resp;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public Task<DiceSimulation> Simulate(DiceSet set, int trials)
    {
        var sim = _diceSimulationFactory.CreateSimulation(set, trials, 0);
        //_diceSimulationCache.AddDiceSimulation(sim);
        return Task.FromResult(sim);
    }

    public IDto Simulate(IDto request)
    {
        if (request is DiceSimulationRequestDto req)
        {
            var sim = _diceSimulationFactory.CreateSimulation(req.ToDiceSet(), req.Trials, req.Modifier);
            //_diceSimulationCache.AddDiceSimulation(sim);
            return new DiceSimulationResponseDto(sim);
        }
        else
        {
            throw new ArgumentException();
        }

        ;
    }

    public IDto DiceRoll(IDto request)
    {
        if (request is DiceRollRequestDto req)
        {
            //var roll = req.dtoToRoll();
            return new DiceRollResponseDto(
                d4: req.D4,
                d6: req.D6,
                d8: req.D8,
                d10: req.D10,
                d12: req.D12,
                d20: req.D20,
                d100: req.D100,
                modifier: req.Modifier,
                total: req.ToDiceSet().Roll() + req.Modifier);
        }

        throw new ArgumentException();
    }
}