using Dnd.Core.Main.Models.Dice;
using MathNet.Numerics.Statistics;

namespace Dnd.Application.Main.Models.Dice;

public class DiceSimulation : IDiceSimulation
{
    public IDiceSet SimDice { get; set; }
    public int Trials { get; set; }
    public int? DC { get; set; }
    public int Modifier { get; set; }

    //public Dictionary<int, int> Results { get; set; }

    public List<ISimResult> Results { get; set; }

    public DescriptiveStatistics Stats { get; set; }

    public DiceSimulation(IDiceSet simDice, int trials, int modifier = 0)
    {
        SimDice = simDice;
        Trials = trials;
        Modifier = modifier;
        Results = new();

        Enumerable.Range(0, Trials).ToList().ForEach(_ =>
        {
            int res = SimDice.Roll() + Modifier;
            var result = Results.FirstOrDefault(r => r.Value == res);
            if (result != null)
            {
                result.Frequency++;
            }
            else
            {
                Results.Add(new SimResult { Value = res, Frequency = 1 });
            }
        });

        Stats = new DescriptiveStatistics(Results.SelectMany(r => Enumerable.Repeat(r.Value, r.Frequency))
            .Select(v => (double)v));
    }

    public string GetResults() => string.Join(", ", Results);
}