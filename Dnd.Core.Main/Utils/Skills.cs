// namespace Dnd.Core.Main.Utils;
//
// public enum Skill
// {
//     Acrobatics,
//     AnimalHandling,
//     Arcana,
//     Athletics,
//     Deception,
//     History,
//     Insight,
//     Intimidation,
//     Investigation,
//     Medicine,
//     Nature,
//     Perception,
//     Performance,
//     Persuasion,
//     Religion,
//     SleightOfHand,
//     Stealth,
//     Survival
// }
//
// public struct SkillModifiers
// {
//     private readonly Dictionary<Skill, int> modifiers;
//
//     public SkillModifiers()
//     {
//         modifiers = new();
//     }
//
//     public int this[Skill skill]
//     {
//         get { return modifiers.TryGetValue(skill, out int modifier) ? modifier : 0; }
//         set { modifiers[skill] = value; }
//     }
// }