// // See https://aka.ms/new-console-template for more information
//
// using System.Text.Json;
// using Dnd.API;
// using Dnd.API.Models.Characters;
// using Dnd.API.Models.Rolls;
//
// namespace ConsoleSandbox;
//
// internal class Program
// {
//     public static void Main(string[] args)
//     {
//         //Scenario: Theodred rolls a wisdom save, and follows up with an eldritch blast
//         // Character theodred = new Character("Theodred", 6,
//         //     new CharacterStats(
//         //         10,
//         //         15,
//         //         8,
//         //         16,
//         //         16,
//         //         17,
//         //         2,
//         //         3,
//         //         6,
//         //         3,
//         //         3,
//         //         3,
//         //         3,
//         //         6,
//         //         6,
//         //         3,
//         //         3,
//         //         3,
//         //         3,
//         //         3,
//         //         6,
//         //         2,
//         //         2,
//         //         6,
//         //         [
//         //             "Wisdom",
//         //             "Charisma",
//         //             "Arcana",
//         //             "Athletics",
//         //             "Intimidation",
//         //             "Investigation",
//         //             "Religion",
//         //             "Survival"
//         //         ]),
//         //     Dnd.API.Constants.Classes["Warlock"]);
//         // int wis_dc = 10;
//         // int wisSave = theodred.SavingThrow("Wisdom");
//         // if (wisSave >= wis_dc)
//         // {
//         //     Console.WriteLine($"Theodred passes a DC 10 wisdom save with a {wisSave}!");
//         // }
//         // else
//         // {
//         //     Console.WriteLine($"Theodred fails a DC 10 wisdom save with a {wisSave}!");
//         // }
//         //
//         // Console.WriteLine("Theodred casts an eldritch blast (3 blasts)");
//         // int ac = 15;
//         // int numBlasts = 3;
//         // for (int i = 0; i < numBlasts; i++)
//         // {
//         //     int attackRoll = theodred.SpellAttack();
//         //     if (attackRoll >= ac)
//         //     {
//         //         int dmg = new DamageRoll(1, 10, 3).Roll();
//         //         Console.WriteLine($"Theodred hits for {dmg} damage!");
//         //     }
//         //     else
//         //     {
//         //         Console.WriteLine("Miss");
//         //     }
//         // }
//         Character testChar = new Character(
//             name: "Test",
//             level: 1,
//             stats: new CharacterStats(
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 10,
//                 new List<string>()),
//             charClass: Constants.Classes["Warlock"]);
//
//         SpellAttackRoll test = new SpellAttackRoll(testChar);
//         try
//         {
//             string json = JsonSerializer.Serialize(test);
//             Console.WriteLine(json);
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e);
//         }
//     }
// }

namespace ConsoleSandbox;

internal class Program()
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Sandbox");
    }
}