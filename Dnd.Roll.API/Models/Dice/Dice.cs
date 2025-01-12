namespace Dnd.Roll.API.Models.Dice;

public class Dice
{
    public int NumSides { get; set; }
    public string Name => "d" + NumSides;

    public Dice(int numSides)
    {
        if (Constants.DiceSideValues.Contains(numSides))
        {
            NumSides = numSides;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public int Roll() => new Random().Next(1, NumSides + 1);
}