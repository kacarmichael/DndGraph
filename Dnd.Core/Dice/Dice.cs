namespace Dnd.Core.Dice;

public class Dice
{
    private readonly int _numSides;

    public Dice(int numSides)
    {
        if (Constants.DiceSideValues.Contains(numSides))
        {
            _numSides = numSides;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public int Roll() => new Random().Next(1, _numSides + 1);
}