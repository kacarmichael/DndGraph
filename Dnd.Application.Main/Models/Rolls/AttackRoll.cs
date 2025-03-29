using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Dice;

namespace Dnd.Application.Main.Models.Rolls;

public class MeleeAttackRoll : DiceRollBase
{
    //public void Initialize() => Value = Roll();

    public MeleeAttackRoll()
    {
    }

    public MeleeAttackRoll(ICharacter character, IDiceSet diceRolled)
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
               Roller.ProficiencyModifier;
    }

    public override string Describe() => Roller.Name + " Melee Attack";
}

public class RangedAttackRoll : DiceRollBase
{
    //public void Initialize() => Value = Roll();

    public RangedAttackRoll()
    {
    }

    public RangedAttackRoll(ICharacter character, IDiceSet diceRolled)
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
               Roller.ProficiencyModifier;
    }

    public override string Describe() => Roller.Name + " Ranged Attack";
}