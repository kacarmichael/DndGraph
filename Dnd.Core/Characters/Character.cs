using Dnd.Core.Rolls;

namespace Dnd.Core.Characters;

public class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int AC { get; set; }
    public CharacterStats Stats { get; set; }

    public Class Class { get; set; }

    public int ProficiencyModifier => Level / 4 + 2;

    public Character(string name, int level, CharacterStats stats, Class charClass)
    {
        Name = name;
        Level = level;
        Stats = stats;
        Class = charClass;
    }

    public int Check(string ability) => new AbilityCheckRoll(ability, this).Roll();

    public int SavingThrow(string ability) => new SavingThrowRoll(ability, this).Roll();

    public int MeleeAttack() => new MeleeAttackRoll(this).Roll();

    public int RangedAttack() => new RangedAttackRoll(this).Roll();

    public int SpellAttack() => new SpellAttackRoll(this).Roll();
}