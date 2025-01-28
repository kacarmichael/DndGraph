using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Dice.Implementations;

public class DiceSimulation : IDiceSimulation
{
    public IDiceSet SimDice { get; set; }
    public int Trials { get; set; }
    public int? DC { get; set; }

    public Dictionary<int, int> Results { get; set; } = new();

    public DiceSimulation(IDiceSet simDice, int trials)
    {
        SimDice = simDice;
        Trials = trials;
        for (int i = 0; i < Trials; i++)
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