using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.Models.Rolls;

public class AbilityCheckRoll : DiceRollBase
{
    public string Ability { get; set; }

    public AbilityCheckRoll()
    {
    }

    public AbilityCheckRoll(string ability, Character character, DiceSet diceRolled)
    {
        Ability = ability;
        Roller = character;
        RollType = "abilityCheck";
        Value = Roll();
        DiceRolled = diceRolled;
    }

    public override int Roll()
    {
        int res = 0;
        if (Constants.AbilityNames.Contains(Ability))
        {
            res = DiceRolled.Roll() +
                  Roller.Stats.AbilityCheckModifier(Roller.Stats.Abilities.GetAbility(Ability).Name);
            return res;
        }


        if (Constants.SkillNames.Contains(Ability))
        {
            res = DiceRolled.Roll() + Roller.Stats.SkillCheckModifier(Roller.Stats.Skills.GetSkill(Ability).Name);
        }

        throw new ArgumentException("Invalid Ability");
    }

    public override string Describe() => "Ability Check: " + Ability;
}