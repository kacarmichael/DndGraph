using Dnd.Application.Main.Models.Characters;

namespace Dnd.Application.Main.Utils;

public class ClassMapper
{
    public Class Map(string className)
    {
        return Constants.Classes[className];
    }
}