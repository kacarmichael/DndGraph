namespace Dnd.Core.Main.Models.Characters.Stats;

public interface ICharacterStats
{
    int StatBlockId { get; set; }
    int CharacterId { get; set; }
    int Level { get; set; }
    IAbilityBlock Abilities { get; set; }
    ISkillBlock Skills { get; set; }
    int ProficiencyBonus { get; set; }
    string ToJson();

    bool Equals(Object? other);
    static bool Compare(ICharacterStats character1, ICharacterStats character2) => character1.Equals(character2);

    int AbilityCheckModifier(AbilityName ability);
    int AbilityCheckModifier(string ability);
    int SaveThrowModifier(AbilityName ability);
    int SaveThrowModifier(string ability);
    int SkillCheckModifier(SkillName skill);
    int SkillCheckModifier(string skill);

    (Dictionary<String, int>, Dictionary<String, int>, List<String>) GetStatsDictionary();
}