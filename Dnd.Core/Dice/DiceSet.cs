namespace Dnd.Core.Dice;

public class DiceSet
{
    public int NumDice { get; set; }
    public int NumSides { get; set; }

    public DiceSet(int? numDice, int? numSides)
    {
        if (numDice == null || numSides == null)
        {
            throw new ArgumentException();
        }

        NumDice = numDice ?? 1;
        NumSides = numSides ?? 6;
    }

    public int Roll()
    {
        var total = 0;
        for (int i = 0; i < NumDice; i++)
        {
            total += new Dice(NumSides).Roll();
        }

        return total;
    }
}