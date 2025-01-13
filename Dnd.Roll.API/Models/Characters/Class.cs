namespace Dnd.Roll.API.Models.Characters;

public class Class
{
    
    public int Id { get; set; }
    
    public string? SpellcastingAbility { get; set; }

    public string? Name { get; set; }
    
    public List<Character>? Characters { get; set; }

    public Class() { }

    public Class(string? spellcastingAbility, string? name, List<Character>? characters)
    {
        Name = name;
        if (!Constants.AbilityNames.Contains(spellcastingAbility))
        {
            throw new ArgumentException("Invalid Spellcasting Ability");
        }

        SpellcastingAbility = spellcastingAbility;
        
        Characters = characters;
    }
}