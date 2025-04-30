using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

public class DamageRoll : DiceRollBase
{
    public int Modifier { get; set; }
    public DiceSet DiceRolled { get; set; }

    public DamageRoll()
    {
    }

    public DamageRoll(int modifier, Character character, DiceSet diceRolled)
    {
        DiceRolled = diceRolled;
        Roller = character;
        RollType = "damageRoll";
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