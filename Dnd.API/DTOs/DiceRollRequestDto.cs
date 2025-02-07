using Dnd.API.Models.Dice.Implementations;

namespace Dnd.API.DTOs;

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
    
    // public DiceSet[] ToDiceSets() => new[]
    // {
    //     D4 != 0 ? new DiceSet(D4, 4): null,
    //     D6 != 0 ? new DiceSet(D6, 6): null,
    //     D8 != 0 ? new DiceSet(D8, 8): null,
    //     D10 != 0 ? new DiceSet(D10, 10): null,
    //     D12 != 0 ? new DiceSet(D12, 12): null,
    //     D20 != 0 ? new DiceSet(D20, 20): null,
    //     D100 != 0 ? new DiceSet(D100, 100): null
    // };

    private int GetDiceSides(int idx) =>
        new[] { 4, 6, 8, 10, 12, 20, 100 }[idx];

    public DiceSet[] ToDiceSets() =>
        new[]
            {
                D4, D6, D8, D10, D12, D20, D100
            }
            .Select((count, index) => count != 0 ? new DiceSet(count, Dice.DiceByIndex(index).NumSides()) : null)
            .OfType<DiceSet>()
            .ToArray();


}