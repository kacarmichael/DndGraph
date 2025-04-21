// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Dnd.Application.Main.Models.Characters.Stats;
// using Dnd.Core.Main.Models.Characters.Stats;
//
// namespace Dnd.Application.Main.Serializers;
//
// public class AbilitySerializer : JsonConverter<IAbility>
// {
//     public override IAbility Read(
//         ref Utf8JsonReader reader,
//         Type typeToConvert,
//         JsonSerializerOptions options)
//     {
//         var ability = new Ability();
//         if (reader.TokenType != JsonTokenType.StartObject)
//         {
//             throw new JsonException("Invalid JSON Ability Object");
//         }
//
//         while (reader.Read())
//         {
//             if (reader.TokenType == JsonTokenType.EndObject)
//             {
//                 return ability;
//             }
//
//             if (reader.TokenType == JsonTokenType.PropertyName)
//             {
//                 var propertyName = reader.GetString();
//                 reader.Read();
//                 if (propertyName == "Score")
//                 {
//                     if (reader.TryGetInt32(out int score))
//                     {
//                         ability.Score = score;
//                     }
//                     else
//                     {
//                         ability.Score = 0;
//                     }
//                 }
//                 else if (propertyName == "Name")
//                 {
//                     ability.Name = reader.GetString() ?? string.Empty;
//                 }
//                 else if (propertyName == "Proficient")
//                 {
//                     ability.Proficient = reader.GetBoolean();
//                 }
//             }
//         }
//
//         return ability;
//     }
//
//
//     public override void Write(
//         Utf8JsonWriter writer,
//         IAbility value,
//         JsonSerializerOptions options)
//     {
//         writer.WriteStartObject();
//         writer.WriteString("Name", value.Name);
//         writer.WriteNumber("Score", (int)value.Score);
//         writer.WriteBoolean("Proficient", value.Proficient);
//         writer.WriteEndObject();
//     }
// }