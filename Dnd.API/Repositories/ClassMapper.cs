using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Repositories;

public class ClassMapper
{
    public IClass Map(string className)
    {
        return Constants.Classes[className];
    }
}