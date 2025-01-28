namespace Dnd.API.Models.Characters.Interfaces;

public interface ICharacterStats
{
    Dictionary<string, int> AbilityModifiers { get; set; }
    Dictionary<string, int> AbilityScores { get; set; }
    Dictionary<string, int> SkillModifiers { get; set; }
    List<string>? Proficiencies { get; set; }
    
    bool Equals(ICharacterStats? other);
    static bool Compare(ICharacterStats character1, ICharacterStats character2) => character1.Equals(character2);
}