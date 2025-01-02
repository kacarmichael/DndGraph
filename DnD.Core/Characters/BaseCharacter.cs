using DnD.Core.Characters;

namespace DnD.Core;

public abstract class BaseCharacter
{
    public string Name { get; set; }
    public CharacterStats Stats { get; set; }
    
    public BaseCharacter()
    {
        Name = string.Empty;
        Stats = new CharacterStats();
    }
    
    public BaseCharacter(string name)
    {
        Name = name;
    }
    
    public BaseCharacter(CharacterStats stats)
    {
        Stats = stats;
    }
    
    public BaseCharacter(string name, CharacterStats stats)
    {
        Name = name;
        Stats = stats;
    }
    
    public int RollCheck(string ability) => Dice.Roll(20) + Stats.GetModifier(ability);
}