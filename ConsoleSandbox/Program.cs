// See https://aka.ms/new-console-template for more information

using System.ComponentModel;

namespace ConsoleSandbox;

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

public class DiceSet
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
            total += new Dice(NumSides).Roll();
        }
        return total;
    }
}

public class DiceSimulation
{
    public DiceSet SimDice { get; set; }
    
    public Dictionary<int, int> Results { get; set; } = new Dictionary<int, int>();
    
    public DiceSimulation(DiceSet simDice, int trials)
    {
        SimDice = simDice;
        for (int i = 0; i < trials; i++)
        {
            int res = SimDice.Roll();
            if (!Results.TryAdd(res, 1))
            {
                Results[res] += 1;
            }
        }
    }
    
    public string GetResults() => string.Join(", ", Results);
}

internal class Program
{
    public static void Main(string[] args)
    {
        DiceSimulation sim = new DiceSimulation(new DiceSet(4, 12), 100000);
        Console.WriteLine(sim.GetResults());
    }
}