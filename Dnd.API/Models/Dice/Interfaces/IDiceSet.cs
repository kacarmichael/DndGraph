// namespace Dnd.API.Models.Dice.Interfaces;
//
// public interface IDiceSet
// {
//     int NumDice { get; set; }
//     int NumSides { get; set; }
//     
//     int Roll();
// }

namespace Dnd.API.Models.Dice.Interfaces;

public interface IDiceSet
{
    int D4 { get; set; }
    int D6 { get; set; }
    int D8 { get; set; }
    int D10 { get; set; }
    int D12 { get; set; }
    int D20 { get; set; }
    int D100 { get; set; }

    int Roll();
}