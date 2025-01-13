//using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.Models.Characters;

public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public int AC { get; set; }
    public CharacterStats? Stats { get; set; }

    public List<Class>? Classes { get; set; }

    public int ProficiencyModifier => Level / 4 + 2;

    public Character() { }

    public Character(string? name, int level, CharacterStats? stats, List<Class>? charClass)
    {
        Name = name;
        Level = level;
        Stats = stats;
        Classes = charClass;
    }

//     public int Check(string ability) => new AbilityCheckRoll(ability, this).Roll();
//
//     public int SavingThrow(string ability) => new SavingThrowRoll(ability, this).Roll();
//
//     public int MeleeAttack() => new MeleeAttackRoll(this).Roll();
//
//     public int RangedAttack() => new RangedAttackRoll(this).Roll();
//
//     public int SpellAttack() => new SpellAttackRoll(this).Roll();
}