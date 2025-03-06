using Dnd.Core.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Dice;

public class Die : IDice
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

    public int NumSides()
    {
        return _maxValue;
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

    public static readonly List<int> DiceTypes = new()
    {
        4,
        6,
        8,
        10,
        12,
        20,
        100
    };

    public static Dictionary<int, Die> DiceBySide = new()
    {
        { 4, D4 },
        { 6, D6 },
        { 8, D8 },
        { 10, D10 },
        { 12, D12 },
        { 20, D20 },
        { 100, D100 }
    };

    public static Die DiceByIndex(int index) =>
        new[] { D4, D6, D8, D10, D12, D20, D100 }[index];
}