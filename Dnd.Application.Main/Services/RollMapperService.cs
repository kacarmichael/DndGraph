using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Core.Main.Models.Rolls;
using Dnd.Core.Main.Services;
using Dnd.Core.Main.Utils;

namespace Dnd.Application.Main.Services;

public class RollMapperService : IRollMapperService
{
    private readonly ICharacterService _characterService;
    private readonly IClassMapperService _classMapper;

    public RollMapperService(ICharacterService characterService, IClassMapperService classMapper)
    {
        _characterService = characterService;
        _classMapper = classMapper;
    }

    public async Task<IDiceRoll> Map(IDto request)
    {
        if (request is RollRequestDto req)
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
                        new DiceSet(d20: 1));

                case "savingThrow":
                    if (req.Ability == null) throw new ArgumentException("Ability cannot be null");
                    if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                    return new SavingThrowRoll(
                        ability: req.Ability,
                        character: c,
                        new DiceSet(d20: 1));

                case "attackRollMelee":
                    if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                    return new MeleeAttackRoll(
                        c,
                        new DiceSet(d20: 1));

                case "attackRollRanged":
                    if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                    return new RangedAttackRoll(
                        c,
                        new DiceSet(d20: 1));

                case "damageRoll":
                    if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                    if (req.DiceRolled == null) throw new ArgumentException("DiceRolled cannot be null");
                    if (req.Modifier == null) throw new ArgumentException("Modifier cannot be null");
                    return new DamageRoll(
                        diceRolled: req.DiceRolled,
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
        else
        {
            throw new ArgumentException("Invalid Request Type " + request.GetType());
        }
    }

    public IDto Map(IDiceRoll roll)
    {
        throw new NotImplementedException();
    }
}