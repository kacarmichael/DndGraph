using System.Text.Json;
using Dnd.Core.Main.Models.Dice;
using Dnd.Core.Main.Utils;
using MathNet.Numerics.Statistics;

namespace Dnd.Application.Main.DTOs;

public class DiceSimulationResponseDto : IDto
{
    public IDiceSet DiceRolled { get; set; }
    public int Modifier { get; set; }
    public List<ISimResult> Results { get; set; }
    public int Trials { get; set; }

    public DescriptiveStatistics Stats { get; set; }

    public DiceSimulationResponseDto(IDiceSet diceRolled, int modifier, List<ISimResult> results, int trials,
        DescriptiveStatistics stats)
    {
        DiceRolled = diceRolled;
        Modifier = modifier;
        Results = results;
        Trials = trials;
        Stats = stats;
    }

    public DiceSimulationResponseDto(IDiceSimulation sim)
    {
        DiceRolled = sim.SimDice;
        Modifier = sim.Modifier;
        Results = sim.Results;
        Trials = sim.Trials;
        Stats = sim.Stats;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}