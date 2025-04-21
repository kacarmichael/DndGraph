// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Dnd.Application.Main.Models.Characters;
// using Dnd.Core.Main.Models.Characters.Stats;
//
// namespace Dnd.Application.Main.Serializers;
//
// public class CharacterStatsSerializer : JsonConverter<ICharacterStats>
// {
//     private readonly JsonSerializerOptions _options;
//
//     public CharacterStatsSerializer()
//     {
//         _options = new JsonSerializerOptions();
//         _options.Converters.Add(new AbilityBlockSerializer());
//         _options.Converters.Add(new SkillBlockSerializer());
//     }
//
//     public override ICharacterStats Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//     {
//         var stats = new CharacterStats();
//
//         if (reader.TokenType != JsonTokenType.StartObject)
//         {
//             throw new JsonException();
//         }
//
//         while (reader.Read())
//         {
//             if (reader.TokenType == JsonTokenType.EndObject)
//             {
//                 return stats;
//             }
//             else if (reader.TokenType == JsonTokenType.PropertyName)
//             {
//                 var propertyName = reader.GetString()!;
//                 reader.Read();
//                 if (propertyName == "Abilities")
//                 {
//                     //reader.Read(); // Move to start of object
//                     stats.Abilities = JsonSerializer.Deserialize<IAbilityBlock>(ref reader, _options)!;
//                 }
//                 else if (propertyName == "Skills")
//                 {
//                     //reader.Read(); // Move to start of object
//                     stats.Skills = JsonSerializer.Deserialize<ISkillBlock>(ref reader, _options)!;
//                 }
//                 else if (propertyName == "ProficiencyBonus")
//                 {
//                     //reader.Read(); // Move to start of object
//                     stats.ProficiencyBonus = reader.GetInt32();
//                 }
//                 else if (propertyName == "Level")
//                 {
//                     //reader.Read(); // Move to start of object
//                     stats.Level = reader.GetInt32();
//                 }
//             }
//         }
//
//         return stats;
//     }
//
//     public override void Write(Utf8JsonWriter writer, ICharacterStats val, JsonSerializerOptions options)
//     {
//         CharacterStats value = (CharacterStats)val;
//         writer.WriteStartObject();
//         writer.WritePropertyName("Abilities");
//         JsonSerializer.Serialize(writer, value.Abilities, _options);
//         writer.WritePropertyName("Skills");
//         JsonSerializer.Serialize(writer, value.Skills, _options);
//         writer.WritePropertyName("ProficiencyBonus");
//         writer.WriteNumberValue(value.ProficiencyBonus);
//         writer.WritePropertyName("Level");
//         writer.WriteNumberValue(value.Level);
//         writer.WriteEndObject();
//     }
// }