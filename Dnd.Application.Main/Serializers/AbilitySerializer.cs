using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Characters.Stats;
using Dnd.Core.Main.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dnd.Application.Main.Serializers;

public class AbilitySerializer : JsonConverter<Ability>
{
    public override Ability Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var ability = new Ability();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return ability;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                if (propertyName == "score")
                {
                    if (reader.TryGetInt32(out int score))
                    {
                        ability.Score = score;
                    }
                    else
                    {
                        ability.Score = 0;
                    }
                }
                else if (propertyName == "name")
                {
                    ability.Name = reader.GetString() ?? string.Empty;
                }
                else if (propertyName == "proficient")
                {
                    ability.Proficient = reader.GetBoolean();
                }
            }
        
        }

        return ability;
    }


    public override void Write(
        Utf8JsonWriter writer,
        Ability value,
        JsonSerializerOptions options)
    {
        writer.WriteString("name", value.Name);
        writer.WriteNumber("score", (int)value.Score);
        writer.WriteBoolean("proficient", value.Proficient);
        writer.WriteEndObject();
    }
        
        
}