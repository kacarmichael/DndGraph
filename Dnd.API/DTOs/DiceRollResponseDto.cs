using System.Text.Json;

namespace Dnd.API.DTOs;

public class DiceRollResponseDto
{
    public int D4 { get; set; }
    public int D6 { get; set; }
    public int D8 { get; set; }
    public int D10 { get; set; }
    public int D12 { get; set; }
    public int D20 { get; set; }
    public int D100 { get; set; }
    public int Total { get; set; }

    public int Modifier { get; set; }

    public DiceRollResponseDto(int d4, int d6, int d8, int d10, int d12, int d20, int d100, int modifier, int total)
    {
        D4 = d4;
        D6 = d6;
        D8 = d8;
        D10 = d10;
        D12 = d12;
        D20 = d20;
        D100 = d100;
        Modifier = modifier;
        Total = total;
    }

    public DiceRollResponseDto(DiceRollRequestDto req)
    {
        D4 = req.D4;
        D6 = req.D6;
        D8 = req.D8;
        D10 = req.D10;
        D12 = req.D12;
        D20 = req.D20;
        D100 = req.D100;
        Modifier = req.Modifier;
        Total = 0;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}