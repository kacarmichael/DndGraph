// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Dnd.Application.Main.Models.Characters.Stats;
// using Dnd.Core.Main.Models.Characters.Stats;
//
// namespace Dnd.Application.Main.Serializers;
//
// public class AbilityBlockSerializer : JsonConverter<IAbilityBlock>
// {
//     private readonly JsonSerializerOptions _options;
//     private readonly AbilitySerializer _abilitySerializer = new();
//
//     public AbilityBlockSerializer()
//     {
//         _options = new JsonSerializerOptions();
//         _options.Converters.Add(new AbilitySerializer());
//     }
//
//     public override IAbilityBlock Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//     {
//         var abilityBlock = new AbilityBlock();
//
//         if (reader.TokenType != JsonTokenType.StartArray)
//         {
//             throw new JsonException();
//         }
//
//         abilityBlock.Abilities = JsonSerializer.Deserialize<List<IAbility>>(ref reader, _options)!;
//
//         return abilityBlock;
//     }
//
//     public override void Write(Utf8JsonWriter writer, IAbilityBlock value, JsonSerializerOptions options)
//     {
//         // writer.WriteStartObject();
//         // writer.WritePropertyName("Abilities");
//         writer.WriteStartArray();
//         foreach (var ability in value.Abilities)
//         {
//             _abilitySerializer.Write(writer, ability, options);
//         }
//
//         writer.WriteEndArray();
//         //writer.WriteEndObject();
//     }
// }