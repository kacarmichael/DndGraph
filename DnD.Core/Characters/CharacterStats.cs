namespace DnD.Core.Characters;

public class CharacterStats
{
    public Dictionary<string, int> Abilities { get; set; }
    public Dictionary<string, Func<int>> Modifiers { get; set; }
    
    public int GetModifier(string ability) => (this.Abilities[ability] - 10) / 2;
    
    public CharacterStats()
    {
        this.Abilities  = new Dictionary<string, int>();
        this.Abilities.Add("Strength", 0);
        this.Abilities.Add("Dexterity", 0);
        this.Abilities.Add("Constitution", 0);
        this.Abilities.Add("Intelligence", 0);
        this.Abilities.Add("Wisdom", 0);
        this.Abilities.Add("Charisma", 0);
        
        this.Modifiers = new Dictionary<string, Func<int>>();
        this.Modifiers.Add("Strength", () => GetModifier("Strength"));
        this.Modifiers.Add("Dexterity", () => GetModifier("Dexterity"));
        this.Modifiers.Add("Constitution", () => GetModifier("Constitution"));
        this.Modifiers.Add("Intelligence", () => GetModifier("Intelligence"));
        this.Modifiers.Add("Wisdom", () => GetModifier("Wisdom"));
        this.Modifiers.Add("Charisma", () => GetModifier("Charisma"));
    }
    
    public CharacterStats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        this.Abilities = new Dictionary<string, int>();
        this.Abilities.Add("Strength", strength);
        this.Abilities.Add("Dexterity", dexterity);
        this.Abilities.Add("Constitution", constitution);
        this.Abilities.Add("Intelligence", intelligence);
        this.Abilities.Add("Wisdom", wisdom);
        this.Abilities.Add("Charisma", charisma);
        
        this.Modifiers = new Dictionary<string, Func<int>>();
        this.Modifiers.Add("Strength", () => GetModifier("Strength"));
        this.Modifiers.Add("Dexterity", () => GetModifier("Dexterity"));
        this.Modifiers.Add("Constitution", () => GetModifier("Constitution"));
        this.Modifiers.Add("Intelligence", () => GetModifier("Intelligence"));
        this.Modifiers.Add("Wisdom", () => GetModifier("Wisdom"));
        this.Modifiers.Add("Charisma", () => GetModifier("Charisma"));
    }
    
    public CharacterStats(Dictionary<string, int> abilities)
    {
        this.Abilities = abilities;
        
        this.Modifiers = new Dictionary<string, Func<int>>();
        this.Modifiers.Add("Strength", () => GetModifier("Strength"));
        this.Modifiers.Add("Dexterity", () => GetModifier("Dexterity"));
        this.Modifiers.Add("Constitution", () => GetModifier("Constitution"));
        this.Modifiers.Add("Intelligence", () => GetModifier("Intelligence"));
        this.Modifiers.Add("Wisdom", () => GetModifier("Wisdom"));
        this.Modifiers.Add("Charisma", () => GetModifier("Charisma"));
    }
    
    public CharacterStats(Dictionary<string, int> abilities, Dictionary<string, Func<int>> modifiers)
    {
        this.Abilities = abilities;
        this.Modifiers = modifiers;
    }
}