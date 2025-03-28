namespace Dnd.Core.Main.Models.Characters.Stats;

public interface ICharacterStats
{
    int Level { get; set; }
    AbilityBlock Abilities { get; set; }
    SkillBlock Skills { get; set; }
    int ProficiencyBonus { get; set; }

    bool Equals(ICharacterStats? other);
    static bool Compare(ICharacterStats character1, ICharacterStats character2) => character1.Equals(character2);
    
    int AbilityCheckModifier(AbilityBlock.AbilityName ability);
    int SaveThrowModifier(AbilityBlock.AbilityName ability);
    int SkillCheckModifier(SkillBlock.SkillName skill);
    
    (Dictionary<String, int>, Dictionary<String, int>, List<String>) GetStatsDictionary();
}

