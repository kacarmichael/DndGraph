using System.Text.Json;
using Dnd.Application.Main.Models.Dice;

namespace Dnd.API.Main.DTOs;

public class DiceRollRequestDto
{
    public int D4 { get; set; }
    public int D6 { get; set; }
    public int D8 { get; set; }
    public int D10 { get; set; }
    public int D12 { get; set; }
    public int D20 { get; set; }
    public int D100 { get; set; }

    public int Modifier { get; set; }

    public DiceRollRequestDto(int d4, int d6, int d8, int d10, int d12, int d20, int d100, int modifier)
    {
        D4 = d4;
        D6 = d6;
        D8 = d8;
        D10 = d10;
        D12 = d12;
        D20 = d20;
        D100 = d100;
        Modifier = modifier;
    }

    public int[] ToArray() => new[] { D4, D6, D8, D10, D12, D20, D100 };

    private int GetDiceSides(int idx) =>
        new[] { 4, 6, 8, 10, 12, 20, 100 }[idx];

    public DiceSet ToDiceSet() =>
        new(D4, D6, D8, D10, D12, D20, D100);

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}