using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dnd.Application.Main.Serializers;

public class SkillSerializer : JsonConverter<Skill>
{
    public override Skill Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var skill = new Skill();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return skill;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                if (propertyName == "name")
                {
                    skill.Name = reader.GetString() ?? string.Empty;
                }
                else if (propertyName == "proficient")
                {
                    skill.Proficient = reader.GetBoolean();
                }
            }
        
        }

        return skill;
    }


    public override void Write(
        Utf8JsonWriter writer,
        Skill value,
        JsonSerializerOptions options)
    {
        writer.WriteString("name", value.Name);
        writer.WriteBoolean("proficient", value.Proficient);
        writer.WriteNumber("modifier", value.Modifier);
        writer.WriteEndObject();
    }
        
        
}