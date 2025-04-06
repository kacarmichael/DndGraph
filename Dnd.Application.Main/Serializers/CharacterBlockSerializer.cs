using System.Text.Json;
using System.Text.Json.Serialization;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Serializers;

public class CharacterBlockSerializer : JsonConverter<CharacterStats>
{
    private readonly JsonSerializerOptions _options;

    public CharacterBlockSerializer()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new AbilityBlockSerializer());
        _options.Converters.Add(new SkillBlockSerializer());
    }

    public override CharacterStats Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stats = new CharacterStats();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return stats;
            }
            else if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString()!;
                if (propertyName == "abilities")
                {
                    reader.Read(); // Move to start of object
                    stats.Abilities = JsonSerializer.Deserialize<AbilityBlock>(ref reader, _options)!;
                }
                else if (propertyName == "skills")
                {
                    reader.Read(); // Move to start of object
                    stats.Skills = JsonSerializer.Deserialize<SkillBlock>(ref reader, _options)!;
                }
                else if (propertyName == "proficiencyBonus")
                {
                    reader.Read(); // Move to start of object
                    stats.ProficiencyBonus = reader.GetInt32();
                }
                else if (propertyName == "level")
                {
                    reader.Read(); // Move to start of object
                    stats.Level = reader.GetInt32();
                }
            }
        }

        return stats;
    }

    public override void Write(Utf8JsonWriter writer, CharacterStats value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("abilities");
        JsonSerializer.Serialize(writer, value.Abilities, _options);
        writer.WritePropertyName("skills");
        JsonSerializer.Serialize(writer, value.Skills, _options);
        writer.WritePropertyName("proficiencyBonus");
        writer.WriteNumberValue(value.ProficiencyBonus);
        writer.WritePropertyName("level");
        writer.WriteNumberValue(value.Level);
        writer.WriteEndObject();
    }
}