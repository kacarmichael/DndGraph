using MathNet.Numerics.Statistics;

namespace Dnd.API.Models.Dice.Interfaces;

public interface IDiceSimulation
{
    IDiceSet SimDice { get; set; }
    int Trials { get; set; }
    int? DC { get; set; }

    DescriptiveStatistics Stats { get; set; }

    int Modifier { get; set; }

    List<ISimResult> Results { get; set; }

    //Dictionary<int, int> Results { get; set; }

    string GetResults();
}