using ConsoleSandbox.Characters;
using ConsoleSandbox.Dice;

namespace ConsoleSandbox.Rolls;

public class SavingThrowRoll(string ability, Character character) : IDiceRoll
{
    public string Describe() => "Saving Throw";

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

        throw new ArgumentException("Invalid Ability");
    }
}