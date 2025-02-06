using Dnd.API.DTOs;
using Dnd.API.Models.Dice.Implementations;
using Dnd.API.Models.Rolls.Implementations;
using Dnd.API.Models.Rolls.Interfaces;
using Dnd.API.Services.Interfaces;

namespace Dnd.API.Services;

public class RollMapperService : IRollMapperService
{
    private readonly ICharacterService _characterService;
    private readonly IClassMapperService _classMapper;

    public RollMapperService(ICharacterService characterService, IClassMapperService classMapper)
    {
        _characterService = characterService;
        _classMapper = classMapper;
    }

    public async Task<IDiceRoll> Map(RollRequestDto req)
    {
        var c = await _characterService.GetCharacterAsync((int)req.CharacterId);
        switch (req.RollType)
        {
            case "abilityCheck":
                if (req.Ability == null) throw new ArgumentException("Ability cannot be null");
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new AbilityCheckRoll(
                    ability: req.Ability,
                    character: c,
                    new DiceSet(1, 20));

            case "savingThrow":
                if (req.Ability == null) throw new ArgumentException("Ability cannot be null");
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new SavingThrowRoll(
                    ability: req.Ability,
                    character: c,
                    new DiceSet(1, 20));

            case "attackRollMelee":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new MeleeAttackRoll(
                    c,
                    new DiceSet(1, 20));

            case "attackRollRanged":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new RangedAttackRoll(
                    c,
                    new DiceSet(1, 20));

            case "damageRoll":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                if (req.NumDice == null) throw new ArgumentException("NumDice cannot be null");
                if (req.NumSides == null) throw new ArgumentException("NumSides cannot be null");
                if (req.Modifier == null) throw new ArgumentException("Modifier cannot be null");
                return new DamageRoll(
                    diceRolled: new DiceSet((int)req.NumDice, (int)req.NumSides),
                    modifier: (int)req.Modifier,
                    character: c);

            case "spellAttackRoll":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                if (req.ClassUsed == null) throw new ArgumentException("ClassUsed cannot be null");
                return new SpellAttackRoll(
                    character: c,
                    classUsed: _classMapper.Map(req.ClassUsed),
                    new DiceSet(1, 20));

            default:
                throw new ArgumentException("Invalid Roll Type " + req.RollType);
        }
    }

    public RollResponseDto Map(IDiceRoll roll)
    {
        throw new NotImplementedException();
    }
}