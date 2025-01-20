using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class SavingThrowRoll : DiceRollBase
{
    
    public string Ability { get; set; }

    public SavingThrowRoll()
    {
    }

    public SavingThrowRoll(string ability, Character character)
    {
        Ability = ability;
        Roller = character;
        RollType = "savingThrow";
        Value = Roll();
    }

    public override string Describe() => "Saving Throw";

    public override int Roll()
    {
        if (!Constants.AbilityNames.Contains(Ability))
        {
            throw new ArgumentException("Invalid Ability");
        }

        int res = new DiceSet(1, 20).Roll() + Roller.Stats.AbilityModifiers[Ability];
        if (Roller.Stats.Proficiencies.Contains(Ability))
        {
            res += Roller.ProficiencyModifier;
        }

        return res;
    }
}