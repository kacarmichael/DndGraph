namespace Dnd.Core.Main.Models.Characters.Stats;

public interface ICharacterStats
{
    int Level { get; set; }
    IAbilityBlock Abilities { get; set; }
    ISkillBlock Skills { get; set; }
    int ProficiencyBonus { get; set; }

    bool Equals(ICharacterStats? other);
    static bool Compare(ICharacterStats character1, ICharacterStats character2) => character1.Equals(character2);

    int AbilityCheckModifier(AbilityName ability);
    int SaveThrowModifier(AbilityName ability);
    int SkillCheckModifier(SkillName skill);

    (Dictionary<String, int>, Dictionary<String, int>, List<String>) GetStatsDictionary();
}