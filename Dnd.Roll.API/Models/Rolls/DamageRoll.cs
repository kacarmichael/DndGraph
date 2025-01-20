using Dnd.Core.Dice;
using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Models.Rolls;

public class DamageRoll : DiceRollBase
{
    public int Modifier { get; set; }
    public int NumDice { get; set; }
    public int NumSides { get; set; }

    private readonly DiceSet _diceSet;

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

        _diceSet = new DiceSet(numDice, numSides);
        Value = Roll();
    }

    // public void Initialize()
    // {
    //     Value = Roll();
    // }

    public override string Describe() => "Damage Roll";

    public override int Roll() => _diceSet.Roll() + Modifier;
}