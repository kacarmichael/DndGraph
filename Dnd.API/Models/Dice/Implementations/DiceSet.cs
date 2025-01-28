using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Dice.Implementations;

public class DiceSet : IDiceSet
{
    public int NumDice { get; set; }
    public int NumSides { get; set; }

    public DiceSet(int numDice, int numSides)
    {
        NumDice = numDice;
        NumSides = numSides;
    }

    public int Roll()
    {
        var total = 0;
        for (int i = 0; i < NumDice; i++)
        {
            total += Constants.DiceTypeSides[NumSides].Roll();
        }

        return total;
    }
}