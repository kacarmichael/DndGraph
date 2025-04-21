// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Dnd.Application.Main.Models.Characters.Stats;
// using Dnd.Core.Main.Models.Characters.Stats;
//
// namespace Dnd.Application.Main.Serializers;
//
// public class SkillSerializer : JsonConverter<ISkill>
// {
//     public override ISkill Read(
//         ref Utf8JsonReader reader,
//         Type typeToConvert,
//         JsonSerializerOptions options)
//     {
//         var skill = new Skill();
//         if (reader.TokenType != JsonTokenType.StartObject)
//         {
//             throw new JsonException();
//         }
//
//         while (reader.Read())
//         {
//             if (reader.TokenType == JsonTokenType.EndObject)
//             {
//                 return skill;
//             }
//
//             if (reader.TokenType == JsonTokenType.PropertyName)
//             {
//                 var propertyName = reader.GetString();
//                 reader.Read();
//                 if (propertyName == "Name")
//                 {
//                     skill.Name = reader.GetString() ?? string.Empty;
//                 }
//                 else if (propertyName == "Proficient")
//                 {
//                     skill.Proficient = reader.GetBoolean();
//                 }
//                 else if (propertyName == "Modifier")
//                 {
//                     skill.Modifier = reader.GetInt32();
//                 }
//             }
//         }
//
//         return skill;
//     }
//
//
//     public override void Write(
//         Utf8JsonWriter writer,
//         ISkill value,
//         JsonSerializerOptions options)
//     {
//         writer.WriteStartObject();
//         writer.WriteString("Name", value.Name);
//         writer.WriteNumber("Modifier", (int)value.Modifier);
//         writer.WriteBoolean("Proficient", value.Proficient);
//         writer.WriteEndObject();
//     }
// }