using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Dice;
using Dnd.API.Models.Dice.Interfaces;

namespace Dnd.API.Models.Rolls.Implementations;

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
        return DiceRolled.Roll() + Roller.Stats.AbilityModifiers["Dexterity"] +
               Roller.ProficiencyModifier;
    }

    public override string Describe() => Roller.Name + " Ranged Attack";
}