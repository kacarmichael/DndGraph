using ConsoleSandbox.Dice;

namespace ConsoleSandbox.Rolls;

public class DamageRoll(int numDice, int numSides, int modifier) : IDiceRoll
{
    public string Describe() => "Damage Roll";

    public int Roll() => new DiceSet(numDice, numSides).Roll() + modifier;
}