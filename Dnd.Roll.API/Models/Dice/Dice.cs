namespace Dnd.Roll.API.Models.Dice;

public class Die
{
    private readonly int _minValue;
    private readonly int _maxValue;
    private readonly Random _random;

    public Die(int maxValue, int minValue = 1)
    {
        _maxValue = maxValue;
        _minValue = minValue;
        _random = new Random();
    }

    public int Roll()
    {
        return _random.Next(_minValue, _maxValue + 1);
    }
}

public static class Dice
{
    public static readonly Die D4 = new Die(4);
    public static readonly Die D6 = new Die(6);
    public static readonly Die D8 = new Die(8);
    public static readonly Die D10 = new Die(10);
    public static readonly Die D12 = new Die(12);
    public static readonly Die D20 = new Die(20);
    public static readonly Die D100 = new Die(100);
}