using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

public class SavingThrowRoll : DiceRollBase
{
    public string Ability { get; set; }

    public SavingThrowRoll()
    {
    }

    public SavingThrowRoll(string ability, ICharacter character, IDiceSet diceRolled)
    {
        Ability = ability;
        Roller = character;
        RollType = "savingThrow";
        Value = Roll();
        DiceRolled = diceRolled;
    }

    public override string Describe() => "Saving Throw";

    public override int Roll()
    {
        if (!Constants.AbilityNames.Contains(Ability))
        {
            throw new ArgumentException("Invalid Ability");
        }

        int res = DiceRolled.Roll() + Roller.Stats.AbilityModifiers[Ability];
        if (Roller.Stats.Proficiencies.Contains(Ability))
        {
            res += Roller.ProficiencyModifier;
        }

        return res;
    }
}