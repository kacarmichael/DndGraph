// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Serializers;

namespace ConsoleSandbox;

class ConsoleSandbox
{
    public static void Main(string[] args)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbilitySerializer());
        options.Converters.Add(new AbilityBlockSerializer());
        var ability = new Ability(name: "Constitution", score: 20, proficient: true);
        var abilityBlock = new AbilityBlock();
        
        Console.WriteLine(JsonSerializer.Serialize(ability, options));
        Console.WriteLine(JsonSerializer.Serialize(abilityBlock, options));
    }
}