using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Dice.Implementations;

public class DiceSimulation : IDiceSimulation
{
    public IDiceSet SimDice { get; set; }
    public int Trials { get; set; }
    public int? DC { get; set; }
    public int Modifier { get; set; }

    public Dictionary<int, int> Results { get; set; } = new();

    public DiceSimulation(IDiceSet simDice, int trials, int modifier = 0)
    {
        SimDice = simDice;
        Trials = trials;
        Modifier = modifier;

        Enumerable.Range(0, Trials).ToList().ForEach(_ =>
        {
            int res = SimDice.Roll() + Modifier;
            Results[res] = Results.TryGetValue(res, out int count) ? count + 1 : 1;
        });
    }

    public string GetResults() => string.Join(", ", Results);
}