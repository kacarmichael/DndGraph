using System.Text.Json;
using System.Text.Json.Serialization;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Serializers;

public class SkillBlockSerializer : JsonConverter<SkillBlock>
{
    private readonly JsonSerializerOptions _options;

    public SkillBlockSerializer()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new SkillSerializer());
    }
    
    public override SkillBlock Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var skillBlock = new SkillBlock();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString()!;
                reader.Read();
                if (propertyName == "skills")
                {
                    skillBlock.Skills = JsonSerializer.Deserialize<List<ISkill>>(ref reader, _options)!;
                }
            }
        }

        return skillBlock;
    }
    
    public override void Write(Utf8JsonWriter writer, SkillBlock value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("skills");
        JsonSerializer.Serialize(writer, value.Skills, _options);
        writer.WriteEndObject();
    }
}