using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

public class SpellAttackRoll : DiceRollBase
{
    [NotMapped] public Class ClassUsed { get; set; }

    public string RollType => "spellAttack";

    public SpellAttackRoll()
    {
    }

    public SpellAttackRoll(Character character, Class classUsed, DiceSet diceRolled)
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
               Roller.Stats.ProficiencyBonus;
    }
}