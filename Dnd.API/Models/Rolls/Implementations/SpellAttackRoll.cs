using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Rolls.Implementations;

public class SpellAttackRoll : DiceRollBase
{
    public IClass ClassUsed { get; set; }

    public string RollType => "spellAttack";

    public SpellAttackRoll()
    {
    }

    public SpellAttackRoll(ICharacter character, IClass classUsed, IDiceSet diceRolled)
    {
        Roller = character;
        ClassUsed = classUsed;
        Value = Roll();
        DiceRolled = diceRolled;
    }

    public override string Describe() => "Spell Attack";

    public override int Roll()
    {
        return DiceRolled.Roll() + Roller.Stats.AbilityModifiers[ClassUsed.SpellcastingAbility] +
               Roller.ProficiencyModifier;
    }
}