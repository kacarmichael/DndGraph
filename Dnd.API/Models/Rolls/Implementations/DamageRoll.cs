using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Rolls.Implementations;

public class DamageRoll : DiceRollBase
{
    public int Modifier { get; set; }
    public IDiceSet DiceRolled { get; set; }

    public DamageRoll()
    {
    }

    public DamageRoll(int modifier, ICharacter character, IDiceSet diceRolled)
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