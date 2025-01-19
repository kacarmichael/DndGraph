using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class SpellAttackRoll : DiceRollBase
{
    public Character Roller { get; }
    
    public Class ClassUsed { get; }

    public void Initialize() => Value = Roll();

    public SpellAttackRoll(Character character, Class classUsed)
    {
        Roller = character;
        ClassUsed = classUsed;
        Initialize();
    }

    public override string Describe() => "Spell Attack";

    public override int Roll()
    {
        return new DiceSet(1, 20).Roll() + Roller.Stats.AbilityModifiers[ClassUsed.SpellcastingAbility] +
               Roller.ProficiencyModifier;
    }
}