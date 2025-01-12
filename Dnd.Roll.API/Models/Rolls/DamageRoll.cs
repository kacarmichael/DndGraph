using Dnd.Core.Dice;
using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Models.Rolls;

public class DamageRoll : DiceRollBase
{
    public Character Roller { get; }
    public int Modifier { get; }
    public int NumDice { get; }
    public int NumSides { get; }

    public DamageRoll(int numDice, int numSides, int modifier, Character character)
    {
        Roller = character;
        NumDice = numDice;
        NumSides = numSides;
        Modifier = modifier;
        Initialize();
    }

    public void Initialize()
    {
        Value = Roll();
    }

    public override string Describe() => "Damage Roll";

    public override int Roll() => new DiceSet(NumDice, NumSides).Roll() + Modifier;
}