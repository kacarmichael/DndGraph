using ConsoleSandbox.Characters;
using ConsoleSandbox.Dice;

namespace ConsoleSandbox.Rolls;

public class AbilityCheckRoll(string ability, Character character) : IDiceRoll
{
    public int Roll()
    {
        int res = 0;
        if (Constants.AbilityNames.Contains(ability))
        {
            res = new DiceSet(1, 20).Roll() + character.Stats.AbilityModifiers[ability];
            if (character.Stats.Proficiencies.Contains(ability))
            {
                res += character.ProficiencyModifier;
            }

            return res;
        }

        if (Constants.SkillNames.Contains(ability))
        {
            res = new DiceSet(1, 20).Roll() + character.Stats.SkillModifiers[ability];
            if (character.Stats.Proficiencies.Contains(ability))
            {
                res += character.ProficiencyModifier;
            }

            return res;
        }

        throw new ArgumentException("Invalid Ability");
    }

    public string Describe() => "Ability Check: " + ability;
}