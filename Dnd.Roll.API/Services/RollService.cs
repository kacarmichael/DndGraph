using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Dice;
using Dnd.Roll.API.Repositories;

namespace Dnd.Roll.API.Services;

public class RollService : IRollService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IRollRepository _rollRepository;
    private readonly IRollMapperService _rollMapperService;

    public RollService(ICharacterRepository characterRepository, IRollRepository rollRepository, IRollMapperService rollMapperService)
    {
        _characterRepository = characterRepository;
        _rollRepository = rollRepository;
        _rollMapperService = rollMapperService;
    }

    public RollResponseDto Roll(RollRequestDto req)
    {
        var character = _characterRepository.GetCharacter((int)req.CharacterId);
        var roll = _rollMapperService.Map(req);
        _rollRepository.AddRoll(roll);
        var resp = _rollMapperService.Map(roll);
        return resp;
    }

    public int Roll(int numSides)
    {
        if (Constants.DiceSideValues.Contains(numSides))
        {
            return Constants.DiceTypeSides[numSides].Roll();
        }
        throw new ArgumentException();
    }

    public int Roll(int numSides, int numDice)
    {
        if (Constants.DiceSideValues.Contains(numSides))
        {
            return Enumerable.Range(0, numDice)
                .Aggregate(0, (sum, _) => 
                    sum + Constants.DiceTypeSides[numSides].Roll());
        }
        throw new ArgumentException();
    }

    public int Roll(DiceSet dice, int modifier = 0)
    {
        return dice.Roll() + modifier;
    }

    public DiceSimulation Simulate(int numDice, int numSides, int trials)
    {
        return new DiceSimulation(
            new DiceSet(numDice, numSides), 
            trials);
    }

    public DiceSimulation Simulate(DiceSet set, int trials)
    {
        return new DiceSimulation(set, trials);
    }

    public DiceSimulation Simulate(int numSides, int trials)
    {
        return new DiceSimulation(
            new DiceSet(1, numSides),
            trials);
    }
}