using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Intermediate;

namespace Dnd.Application.Main.Models.Intermediate;

public class CharacterClass : ICharacterClass
{
    public int CharacterId { get; set; }
    public int ClassId { get; set; }
    public int Levels { get; set; }

    [NotMapped] public virtual ICharacter _character { get; set; }

    [NotMapped] public virtual IClass _class { get; set; }

    public CharacterClass()
    {
    }

    public CharacterClass(int classId, int characterId, int levels)
    {
        ClassId = classId;
        CharacterId = characterId;
        Levels = levels;
    }

    public static IEnumerable<CharacterClass> FromDict(Dictionary<int, int> classes, int characterId)
    {
        var class_list = new List<CharacterClass>();
        foreach (var kvp in classes)
        {
            class_list.Add(new CharacterClass(kvp.Key, characterId: characterId, levels: kvp.Value));
        }

        return class_list;
    }

    public static IEnumerable<CharacterClass> FromDict(Dictionary<int, int> classes)
    {
        var class_list = new List<CharacterClass>();
        foreach (var kvp in classes)
        {
            class_list.Add(new CharacterClass(kvp.Key, characterId: -1, levels: kvp.Value));
        }

        return class_list;
    }
}