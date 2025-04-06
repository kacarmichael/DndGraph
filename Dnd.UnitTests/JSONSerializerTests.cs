using System.Text.Json;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Serializers;
using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.UnitTests;

public class JSONSerializerTests
{
    private readonly JsonSerializerOptions _options;

    private Ability GetTestAbility() => new Ability(name: "Constitution", score: 20, proficient: true);

    private AbilityBlock GetTestAbilityBlock()
    {
        var abilities = new List<IAbility>();
        abilities.Add(new Ability("Constitution", 20, true));
        abilities.Add(new Ability("Dexterity", 20, true));
        abilities.Add(new Ability("Strength", 20, true));
        abilities.Add(new Ability("Intelligence", 20, true));
        abilities.Add(new Ability("Wisdom", 20, true));
        abilities.Add(new Ability("Charisma", 20, true));
        return new AbilityBlock(abilities);
    }

    private Skill GetTestSkill() => new Skill(name: "Acrobatics", modifier: 2, proficient: true);

    private SkillBlock GetTestSkillBlock()
    {
        var skills = new List<ISkill>();
        skills.Add(new Skill("Acrobatics", 2, true));
        skills.Add(new Skill("AnimalHandling", 2, true));
        skills.Add(new Skill("Arcana", 2, true));
        skills.Add(new Skill("Athletics", 2, true));
        skills.Add(new Skill("Deception", 2, true));
        skills.Add(new Skill("History", 2, true));
        skills.Add(new Skill("Insight", 2, true));
        skills.Add(new Skill("Intimidation", 2, true));
        skills.Add(new Skill("Investigation", 2, true));
        skills.Add(new Skill("Medicine", 2, true));
        skills.Add(new Skill("Nature", 2, true));
        skills.Add(new Skill("Perception", 2, true));
        skills.Add(new Skill("Performance", 2, true));
        skills.Add(new Skill("Persuasion", 2, true));
        skills.Add(new Skill("Religion", 2, true));
        skills.Add(new Skill("SleightOfHand", 2, true));
        skills.Add(new Skill("Stealth", 2, true));
        skills.Add(new Skill("Survival", 2, true));
        return new SkillBlock(skills);
    }


    public JSONSerializerTests()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new AbilitySerializer());
        _options.Converters.Add(new AbilityBlockSerializer());
        _options.Converters.Add(new SkillSerializer());
        _options.Converters.Add(new SkillBlockSerializer());
        _options.PropertyNameCaseInsensitive = true;
    }

    [Fact]
    public void AbilitySerializationTest()
    {
        var ability = GetTestAbility();
        var abilityJson = JsonSerializer.Serialize((IAbility)ability, _options);

        Assert.Equal("{\"Name\":\"Constitution\",\"Score\":20,\"Proficient\":true}", abilityJson);
    }

    [Fact]
    public void AbilityDeserializationTest()
    {
        var abilityJson = "{\"Name\":\"Constitution\",\"Score\":20,\"Proficient\":true}";
        var ability = JsonSerializer.Deserialize<IAbility>(abilityJson, _options);

        Assert.Equal("Constitution", ability.Name);
        Assert.Equal(20, ability.Score);
        Assert.True(ability.Proficient);
    }

    [Fact]
    public void SkillSerializationTest()
    {
        var skill = GetTestSkill();
        var skillJson = JsonSerializer.Serialize(skill, _options);

        Assert.Equal("{\"Name\":\"Acrobatics\",\"Modifier\":2,\"Proficient\":true}", skillJson);
    }

    [Fact]
    public void SkillDeserializationTest()
    {
        var skillJson = "{\"Name\":\"Acrobatics\",\"Modifier\":2,\"Proficient\":true}";
        var skill = JsonSerializer.Deserialize<Skill>(skillJson, _options);

        Assert.Equal("Acrobatics", skill.Name);
        Assert.Equal(2, skill.Modifier);
        Assert.True(skill.Proficient);
    }

    [Fact]
    public void AbilityBlockSerializationTest()
    {
        var abilityBlock = GetTestAbilityBlock();
        var abilityBlockJson = JsonSerializer.Serialize((IAbilityBlock)abilityBlock, _options);

        var expectedJson = "{\"Abilities\":[{\"Name\":\"Constitution\",\"Score\":20,\"Proficient\":true}," +
                           "{\"Name\":\"Dexterity\",\"Score\":20,\"Proficient\":true}," +
                           "{\"Name\":\"Strength\",\"Score\":20,\"Proficient\":true}," +
                           "{\"Name\":\"Intelligence\",\"Score\":20,\"Proficient\":true}," +
                           "{\"Name\":\"Wisdom\",\"Score\":20,\"Proficient\":true}," +
                           "{\"Name\":\"Charisma\",\"Score\":20,\"Proficient\":true}]}";
        Assert.Equal(expectedJson, abilityBlockJson);
    }

    [Fact]
    public void AbilityBlockDeserializationTest()
    {
        var abilityBlockJson = "{\"Abilities\":[{\"Name\":\"Constitution\",\"Score\":20,\"Proficient\":true}," +
                               "{\"Name\":\"Dexterity\",\"Score\":20,\"Proficient\":true}," +
                               "{\"Name\":\"Strength\",\"Score\":20,\"Proficient\":true}," +
                               "{\"Name\":\"Intelligence\",\"Score\":20,\"Proficient\":true}," +
                               "{\"Name\":\"Wisdom\",\"Score\":20,\"Proficient\":true}," +
                               "{\"Name\":\"Charisma\",\"Score\":20,\"Proficient\":true}]}";
        var abilityBlock = JsonSerializer.Deserialize<IAbilityBlock>(abilityBlockJson, _options);

        Assert.Equal(6, abilityBlock.Abilities.Count);
    }

    [Fact]
    public void SkillBlockSerializationTest()
    {
        var skillBlock = GetTestSkillBlock();
        var skillBlockJson = JsonSerializer.Serialize((ISkillBlock)skillBlock, _options);

        var expectedJson = "{\"skills\":[{\"Name\":\"Acrobatics\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"AnimalHandling\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Arcana\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Athletics\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Deception\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"History\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Insight\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Intimidation\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Investigation\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Medicine\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Nature\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Perception\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Performance\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Persuasion\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Religion\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"SleightOfHand\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Stealth\",\"Modifier\":2,\"Proficient\":true}," +
                           "{\"Name\":\"Survival\",\"Modifier\":2,\"Proficient\":true}]}";
        Assert.Equal(expectedJson, skillBlockJson);
    }

    [Fact]
    public void SkillBlockDeserializationTest()
    {
        var skillBlockJson = "{\"skills\":[{\"Name\":\"Acrobatics\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Animal Handling\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Arcana\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Athletics\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Deception\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"History\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Insight\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Intimidation\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Investigation\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Medicine\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Nature\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Perception\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Performance\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Persuasion\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Religion\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Sleight of Hand\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Stealth\",\"Modifier\":2,\"Proficient\":true}," +
                             "{\"Name\":\"Survival\",\"Modifier\":2,\"Proficient\":true}]}";
        var skillBlock = JsonSerializer.Deserialize<ISkillBlock>(skillBlockJson, _options);

        Assert.Equal(18, skillBlock.Skills.Count);
    }
}