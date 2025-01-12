namespace Dnd.Roll.API.Models.Characters;

public class Class
{
    public string SpellcastingAbility { get; set; }

    public string Name { get; set; }

    public Class(string spellcastingAbility, string name)
    {
        Name = name;
        if (!Constants.AbilityNames.Contains(spellcastingAbility))
        {
            throw new ArgumentException("Invalid Spellcasting Ability");
        }

        SpellcastingAbility = spellcastingAbility;
    }
}