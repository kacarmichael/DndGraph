using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Dice;

//using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Models.Rolls;

public class MeleeAttackRoll : DiceRollBase
{
    //public void Initialize() => Value = Roll();

    public MeleeAttackRoll()
    {
    }

    public MeleeAttackRoll(Character character, DiceSet diceRolled)
    {
        Roller = character;
        RollType = "attackRollMelee";
        //Initialize();
        DiceRolled = diceRolled;
        Value = Roll();
    }

    public override int Roll()
    {
        return DiceRolled.Roll() + Roller.Stats.AbilityCheckModifier(AbilityName.Strength) +
               Roller.Stats.ProficiencyBonus;
    }

    public override string Describe() => Roller.Name + " Melee Attack";
}

public class RangedAttackRoll : DiceRollBase
{
    //public void Initialize() => Value = Roll();

    public RangedAttackRoll()
    {
    }

    public RangedAttackRoll(Character character, DiceSet diceRolled)
    {
        Roller = character;
        RollType = "attackRollRanged";
        //Initialize();
        DiceRolled = diceRolled;
        Value = Roll();
    }

    public override int Roll()
    {
        return DiceRolled.Roll() + Roller.Stats.AbilityCheckModifier(AbilityName.Dexterity) +
               Roller.Stats.ProficiencyBonus;
    }

    public override string Describe() => Roller.Name + " Ranged Attack";
}