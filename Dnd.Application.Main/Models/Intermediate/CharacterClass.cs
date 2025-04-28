using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Application.Main.Models.Characters;

namespace Dnd.Application.Main.Models.Intermediate;

public class CharacterClass
{
    public int CharacterId { get; set; }
    public int ClassId { get; set; }
    public int Levels { get; set; }

    [NotMapped] public virtual Character _character { get; set; }

    [NotMapped] public virtual Class _class { get; set; }

    public CharacterClass()
    {
    }

    public CharacterClass(Character character, Class cls, int levels)
    {
        _character = character;
        _class = cls;
        Levels = levels;
        CharacterId = _character.Id;
        ClassId = _class.ClassId;
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