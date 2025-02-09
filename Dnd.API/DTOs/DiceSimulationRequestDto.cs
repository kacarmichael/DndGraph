using Dnd.API.Models.Dice.Implementations;

namespace Dnd.API.DTOs;

public class DiceSimulationRequestDto
{
    public int D4 { get; set; }
    public int D6 { get; set; }
    public int D8 { get; set; }
    public int D10 { get; set; }
    public int D12 { get; set; }
    public int D20 { get; set; }
    public int D100 { get; set; }

    public int Modifier { get; set; }

    public int Trials { get; set; }

    public DiceSimulationRequestDto(int d4, int d6, int d8, int d10, int d12, int d20, int d100, int modifier,
        int trials)
    {
        D4 = d4;
        D6 = d6;
        D8 = d8;
        D10 = d10;
        D12 = d12;
        D20 = d20;
        D100 = d100;
        Modifier = modifier;
        Trials = trials;
    }

    public DiceSet ToDiceSet() =>
        new(D4, D6, D8, D10, D12, D20, D100);
}