using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Rolls;
using Dnd.Roll.API.Repositories;

namespace Dnd.Roll.API.Services;

public class RollMapperService : IRollMapperService
{
    private readonly ICharacterService _characterService;
    private readonly ClassMapper _classMapper;

    public RollMapperService(ICharacterService characterService, ClassMapper classMapper)
    {
        _characterService = characterService;
        _classMapper = classMapper;
    }
    
    public DiceRollBase Map(RollRequestDto req)
    {
        switch (req.RollType)   
        {
            case "abilityCheck":
                if (req.Ability == null) throw new ArgumentException("Ability cannot be null");
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new AbilityCheckRoll(
                    ability: req.Ability,
                    character: _characterService.GetCharacterById((int)req.CharacterId));
            
            case "savingThrow":
                if (req.Ability == null) throw new ArgumentException("Ability cannot be null");
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new SavingThrowRoll(
                    ability: req.Ability,
                    character: _characterService.GetCharacterById((int)req.CharacterId));
            
            case "attackRollMelee":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new MeleeAttackRoll(
                    character: _characterService.GetCharacterById((int)req.CharacterId));
            
            case "attackRollRanged":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                return new RangedAttackRoll(
                    character: _characterService.GetCharacterById((int)req.CharacterId));
            
            case "damageRoll":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                if (req.NumDice == null) throw new ArgumentException("NumDice cannot be null");
                if (req.NumSides == null) throw new ArgumentException("NumSides cannot be null");
                if (req.Modifier == null) throw new ArgumentException("Modifier cannot be null");
                return new DamageRoll(
                    numDice: (int)req.NumDice,
                    numSides: (int)req.NumSides,
                    modifier: (int)req.Modifier,
                    character: _characterService.GetCharacterById((int)req.CharacterId));
            
            case "spellAttackRoll":
                if (req.CharacterId == null) throw new ArgumentException("CharacterId cannot be null");
                if (req.ClassUsed == null) throw new ArgumentException("ClassUsed cannot be null");
                return new SpellAttackRoll(
                    character: _characterService.GetCharacterById((int)req.CharacterId),
                    classUsed: _classMapper.Map(req.ClassUsed));
            
            default:
                throw new ArgumentException("Invalid Roll Type " + req.RollType);
        }
    }

    public RollResponseDto Map(DiceRollBase diceRoll)
    {
        throw new NotImplementedException();
    }
}