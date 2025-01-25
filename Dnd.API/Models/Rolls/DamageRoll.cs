using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class DamageRoll : DiceRollBase
{
    public int Modifier { get; set; }
    public int NumDice { get; set; }
    public int NumSides { get; set; }

    public DamageRoll()
    {
    }

    public DamageRoll(int numDice, int numSides, int modifier, Character character)
    {
        Roller = character;
        RollType = "damageRoll";
        NumDice = numDice;
        NumSides = numSides;
        Modifier = modifier;

        DiceRolled = new DiceSet(numDice, numSides);
        Value = Roll();
    }

    // public void Initialize()
    // {
    //     Value = Roll();
    // }

    public override string Describe() => "Damage Roll";

    public override int Roll() => DiceRolled.Roll() + Modifier;
}