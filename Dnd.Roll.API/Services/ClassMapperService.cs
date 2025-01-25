using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Services;

public class ClassMapperService : IClassMapperService
{
    public Class Map(string className) => Constants.Classes[className];
}