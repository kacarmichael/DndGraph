using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Dice;

namespace Dnd.Roll.API.Models.Rolls;

public class MeleeAttackRoll : DiceRollBase
{
    //public void Initialize() => Value = Roll();

    public MeleeAttackRoll()
    {
    }

    public MeleeAttackRoll(Character character)
    {
        Roller = character;
        RollType = "attackRollMelee";
        //Initialize();
        Value = Roll();
        DiceRolled = new DiceSet(1, 20);
    }

    public override int Roll()
    {
        return DiceRolled.Roll() + Roller.Stats.AbilityModifiers["Strength"] + Roller.ProficiencyModifier;
    }

    public override string Describe() => Roller.Name + " Melee Attack";
}

public class RangedAttackRoll : DiceRollBase
{
    //public void Initialize() => Value = Roll();

    public RangedAttackRoll()
    {
    }

    public RangedAttackRoll(Character character)
    {
        Roller = character;
        RollType = "attackRollRanged";
        //Initialize();
        Value = Roll();
    }

    public override int Roll()
    {
        return DiceRolled.Roll() + Roller.Stats.AbilityModifiers["Dexterity"] +
               Roller.ProficiencyModifier;
    }

    public override string Describe() => Roller.Name + " Ranged Attack";
}