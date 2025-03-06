using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

public class AbilityCheckRoll : DiceRollBase
{
    public string Ability { get; set; }

    public AbilityCheckRoll()
    {
    }

    public AbilityCheckRoll(string ability, ICharacter character, IDiceSet diceRolled)
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
            res = DiceRolled.Roll() + Roller.Stats.AbilityModifiers[Ability];
            if (Roller.Stats.Proficiencies.Contains(Ability))
            {
                res += Roller.ProficiencyModifier;
            }

            return res;
        }


        if (Constants.SkillNames.Contains(Ability))
        {
            res = DiceRolled.Roll() + Roller.Stats.SkillModifiers[Ability];
            if (Roller.Stats.Proficiencies.Contains(Ability))
            {
                res += Roller.ProficiencyModifier;
            }

            return res;
        }

        throw new ArgumentException("Invalid Ability");
    }

    public override string Describe() => "Ability Check: " + Ability;
}