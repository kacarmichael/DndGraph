namespace DnD.Core;

public static class Dice
{
    public static int Roll(int sides) => new Random().Next(1, sides + 1);
    
    public static int Roll(int numDie, int sides) => Enumerable.Range(1, numDie).Select(_ => Roll(sides)).Sum();
}