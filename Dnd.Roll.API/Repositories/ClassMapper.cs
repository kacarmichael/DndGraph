using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Repositories;

public class ClassMapper
{
    public Class Map(string className)
    {
        return Constants.Classes[className];
    }
}