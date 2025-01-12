namespace Dnd.Roll.API.Models.Dice;

public class DiceSimulation
{
    public DiceSet SimDice { get; set; }
    public int Trials { get; set; }
    public int DC { get; set; }

    public Dictionary<int, int> Results { get; set; } = new();

    public DiceSimulation(DiceSet simDice, int trials)
    {
        SimDice = simDice;
        Trials = trials;
        for (int i = 0; i < Trials; i++)
        {
            int res = SimDice.Roll();
            if (!Results.TryAdd(res, 1))
            {
                Results[res] += 1;
            }
        }
    }

    public string GetResults() => string.Join(", ", Results);
}