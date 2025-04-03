using System.Text.Json;
using System.Text.Json.Serialization;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Core.Main.Models.Characters.Stats;

namespace Dnd.Application.Main.Serializers;

public class AbilityBlockSerializer : JsonConverter<AbilityBlock>
{
    private readonly JsonSerializerOptions _options;

    public AbilityBlockSerializer()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new AbilitySerializer());
    }
    
    public override AbilityBlock Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var abilityBlock = new AbilityBlock();
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
                if (propertyName == "abilities")
                {
                    abilityBlock.Abilities = JsonSerializer.Deserialize<List<IAbility>>(ref reader, _options)!;
                }
            }
        }

        return abilityBlock;
    }
    
    public override void Write(Utf8JsonWriter writer, AbilityBlock value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("abilities");
        JsonSerializer.Serialize(writer, value.Abilities, _options);
        writer.WriteEndObject();
    }
}