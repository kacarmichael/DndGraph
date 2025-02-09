using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.DTOs;

public class DiceSimulationResponseDto
{
    public IDiceSet DiceRolled;
    public int Modifier;
    public Dictionary<int, int> Results;
    public int Trials;

    public DiceSimulationResponseDto(IDiceSet diceRolled, int modifier, Dictionary<int, int> results, int trials)
    {
        DiceRolled = diceRolled;
        Modifier = modifier;
        Results = results;
        Trials = trials;
    }
}