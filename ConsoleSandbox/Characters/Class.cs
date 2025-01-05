namespace ConsoleSandbox.Characters;

public class Class
{
    public string SpellcastingAbility { get; set; }

    public Class(string spellcastingAbility)
    {
        if (!Constants.AbilityNames.Contains(spellcastingAbility))
        {
            throw new ArgumentException("Invalid Spellcasting Ability");
        }

        SpellcastingAbility = spellcastingAbility;
    }
}