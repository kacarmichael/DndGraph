using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class AbilityCheckRoll : DiceRollBase
{
    public Character Roller { get; }

    public string Ability { get; }
    public void Initialize() => Value = Roll();

    public AbilityCheckRoll(string Ability, Character character)
    {
        Ability = Ability;
        Roller = character;
    }

    public override int Roll()
    {
        int res = 0;
        if (Constants.AbilityNames.Contains(Ability))
        {
            res = new DiceSet(1, 20).Roll() + Roller.Stats.AbilityModifiers[Ability];
            if (Roller.Stats.Proficiencies.Contains(Ability))
            {
                res += Roller.ProficiencyModifier;
            }

            return res;
        }

        if (Constants.SkillNames.Contains(Ability))
        {
            res = new DiceSet(1, 20).Roll() + Roller.Stats.SkillModifiers[Ability];
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