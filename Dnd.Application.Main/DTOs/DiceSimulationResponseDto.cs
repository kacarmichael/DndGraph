using System.Text.Json;
using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Utils;
using MathNet.Numerics.Statistics;

namespace Dnd.Application.Main.DTOs;

public class DiceSimulationResponseDto : IDto
{
    public DiceSet DiceRolled { get; set; }
    public int Modifier { get; set; }
    public List<SimResult> Results { get; set; }
    public int Trials { get; set; }

    public DescriptiveStatistics Stats { get; set; }

    public DiceSimulationResponseDto(DiceSet diceRolled, int modifier, List<SimResult> results, int trials,
        DescriptiveStatistics stats)
    {
        DiceRolled = diceRolled;
        Modifier = modifier;
        Results = results;
        Trials = trials;
        Stats = stats;
    }

    public DiceSimulationResponseDto(DiceSimulation sim)
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