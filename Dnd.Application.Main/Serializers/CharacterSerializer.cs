// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Dnd.Application.Main.Models.Characters;
// using Dnd.Core.Main.Models.Characters;
// using Dnd.Core.Main.Models.Characters.Stats;
//
// namespace Dnd.Application.Main.Serializers;
//
// public class CharacterSerializer : JsonConverter<ICharacter>
// {
//     private readonly JsonSerializerOptions _options;
//
//     public CharacterSerializer()
//     {
//         _options = new JsonSerializerOptions();
//         _options.Converters.Add(new CharacterStatsSerializer());
//     }
//
//     public override ICharacter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//     {
//         var character = new Character();
//         if (reader.TokenType != JsonTokenType.StartObject)
//         {
//             throw new JsonException("Invalid JSON when serializing Character Object");
//         }
//
//         while (reader.Read())
//         {
//             if (reader.TokenType == JsonTokenType.EndObject)
//             {
//                 return character;
//             }
//
//             if (reader.TokenType == JsonTokenType.PropertyName)
//             {
//                 if (reader.GetString() == "Name")
//                 {
//                     character.Name = reader.GetString() ?? string.Empty;
//                 }
//                 else if (reader.GetString() == "Level")
//                 {
//                     character.Level = reader.GetInt32();
//                 }
//                 else if (reader.GetString() == "Stats")
//                 {
//                     character.Stats = JsonSerializer.Deserialize<ICharacterStats>(ref reader, _options)!;
//                 }
//                 else if (reader.GetString() == "AC")
//                 {
//                     character.AC = reader.GetInt32();
//                 }
//                 else if (reader.GetString() == "Classes")
//                 {
//                     character.Classes = JsonSerializer.Deserialize<Dictionary<string, int>>(ref reader, _options)!;
//                 }
//             }
//         }
//
//         return character;
//     }
//     
//     public override void Write(Utf8JsonWriter writer, ICharacter value, JsonSerializerOptions options)
//     {
//         Character character = (Character)value;
//         writer.WriteStartObject();
//         writer.WriteString("Name", character.Name ?? string.Empty);
//         writer.WriteNumber("Level", character.Level);
//         writer.WritePropertyName("Stats");
//         JsonSerializer.Serialize(writer, character.Stats, _options);
//         writer.WriteNumber("AC", character.AC);
//         writer.WritePropertyName("Classes");
//         JsonSerializer.Serialize(writer, character.Classes, _options);
//         writer.WriteEndObject();
//     }
// }

