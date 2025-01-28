using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Dice;
using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Rolls.Implementations;

public class DamageRoll : DiceRollBase
{
    public int Modifier { get; set; }
    public int NumDice { get; set; }
    public int NumSides { get; set; }

    public DamageRoll()
    {
    }

    public DamageRoll(int modifier, ICharacter character, IDiceSet diceRolled)
    {
        DiceRolled = diceRolled;
        Roller = character;
        RollType = "damageRoll";
        NumDice = diceRolled.NumDice;
        NumSides = diceRolled.NumSides;
        Modifier = modifier;
        
        Value = Roll();
    }

    // public void Initialize()
    // {
    //     Value = Roll();
    // }

    public override string Describe() => "Damage Roll";

    public override int Roll() => DiceRolled.Roll() + Modifier;
}