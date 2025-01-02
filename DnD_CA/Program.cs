// See https://aka.ms/new-console-template for more information

using DnD.Core;
using DnD.Core.Characters;

/*
var d4 = new D4();

Console.WriteLine(d4.Value);

d4.Roll();

Console.WriteLine(d4.Value);
*/

//Roll w/advantage
/*
var res = Math.Max(Dice.Roll(20), Dice.Roll(20));

Console.WriteLine(res);
*/

//Roll w/disadvantage
/*
var res = Math.Min(Dice.Roll(20), Dice.Roll(20));

Console.WriteLine(res);
*/

//Attack roll
//2 d6 + 4
/*
var res = Dice.Roll(2, 6) + 4;

Console.WriteLine(res); 
*/

//Character creation
var stats = new CharacterStats(10, 15, 8, 16, 16, 17);
var theodred = new PlayerCharacter("theodred", stats);

// Console.WriteLine(theodred.Name);
//
// foreach (var stat in theodred.Stats.Abilities)
// {
//     Console.WriteLine($"{stat.Key}: {stat.Value}");
//     Console.WriteLine("Modifier: {0}", theodred.Stats.Modifiers[stat.Key]());
// }

foreach (var ability in theodred.Stats.Abilities.Keys)
{
    Console.WriteLine($"{ability}: " + theodred.RollCheck(ability));
}
