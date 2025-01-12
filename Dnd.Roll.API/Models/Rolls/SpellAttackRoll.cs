using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class SpellAttackRoll : DiceRollBase
{
    public Character Roller { get; }

    public void Initialize() => Value = Roll();

    public SpellAttackRoll(Character character)
    {
        Roller = character;
        Initialize();
    }

    public override string Describe() => "Spell Attack";

    public override int Roll()
    {
        return new DiceSet(1, 20).Roll() + Roller.Stats.AbilityModifiers[Roller.Class.SpellcastingAbility] +
               Roller.ProficiencyModifier;
    }
}