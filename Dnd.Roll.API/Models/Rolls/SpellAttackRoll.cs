using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class SpellAttackRoll : DiceRollBase
{
    public Class ClassUsed { get; set; }

    public string RollType => "spellAttack";
    
    public SpellAttackRoll() { }

    public SpellAttackRoll(Character character, Class classUsed)
    {
        Roller = character;
        ClassUsed = classUsed;
        Value = Roll();
        DiceRolled = new DiceSet(1, 20);
        
    }

    public override string Describe() => "Spell Attack";

    public override int Roll()
    {
        return DiceRolled.Roll() + Roller.Stats.AbilityModifiers[ClassUsed.SpellcastingAbility] +
               Roller.ProficiencyModifier;
    }
}