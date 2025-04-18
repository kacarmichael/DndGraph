namespace Dnd.Core.Main.Models.Characters;

public interface IClass
{
    int ClassId { get; set; }
    string SpellcastingAbility { get; set; }
    string Name { get; set; }
}