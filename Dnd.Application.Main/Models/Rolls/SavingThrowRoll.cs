using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.Models.Rolls;

public class SavingThrowRoll : DiceRollBase
{
    public string Ability { get; set; }

    public SavingThrowRoll()
    {
    }

    public SavingThrowRoll(string ability, Character character, DiceSet diceRolled)
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

        int res = DiceRolled.Roll() + Roller.Stats.SaveThrowModifier(Roller.Stats.Abilities.GetAbility(Ability).Name);

        return res;
    }
}