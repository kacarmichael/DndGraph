using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

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
        return DiceRolled.Roll() +
               Roller.Stats.AbilityCheckModifier(Roller.Stats.Abilities.GetAbility(ClassUsed.SpellcastingAbility)
                   .Name) +
               Roller.ProficiencyModifier;
    }
}