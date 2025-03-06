// using Dnd.API.Models.Dice.Interfaces;
//
// namespace Dnd.API.Models.Dice.Implementations;
//
// public class DiceSet : IDiceSet
// {
//     public int NumDice { get; set; }
//     public int NumSides { get; set; }
//
//     public DiceSet(int numDice, int numSides)
//     {
//         NumDice = numDice;
//         NumSides = numSides;
//     }
//
//     public int Roll()
//     {
//         var total = 0;
//         for (int i = 0; i < NumDice; i++)
//         {
//             total += Dice.DiceBySide[NumSides].Roll();
//         }
//
//         return total;
//     }
// }

using Dnd.Core.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Dice;

public class DiceSet : IDiceSet
{
    public int D4 { get; set; }
    public int D6 { get; set; }
    public int D8 { get; set; }
    public int D10 { get; set; }
    public int D12 { get; set; }
    public int D20 { get; set; }
    public int D100 { get; set; }

    public DiceSet(int d4 = 0, int d6 = 0, int d8 = 0, int d10 = 0, int d12 = 0, int d20 = 0, int d100 = 0)
    {
        D4 = d4;
        D6 = d6;
        D8 = d8;
        D10 = d10;
        D12 = d12;
        D20 = d20;
        D100 = d100;
    }

    public DiceSet(int[] dice)
    {
        if (dice.Length != 7)
        {
            throw new ArgumentException();
        }

        D4 = dice[0];
        D6 = dice[1];
        D8 = dice[2];
        D10 = dice[3];
        D12 = dice[4];
        D20 = dice[5];
        D100 = dice[6];
    }

    public int[] ToArray()
    {
        return new[]
        {
            D4, D6, D8, D10, D12, D20, D100
        };
    }

    public int Roll()
    {
        return ToArray()
            .Select((value, index) => Enumerable.Range(0, value).Select(_ => Dice.DiceByIndex(index).Roll()).Sum())
            .Sum();
    }
}