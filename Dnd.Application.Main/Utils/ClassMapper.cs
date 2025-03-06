using Dnd.Core.Main.Models.Characters;

namespace Dnd.Application.Main.Utils;

public class ClassMapper
{
    public IClass Map(string className)
    {
        return Constants.Classes[className];
    }
}