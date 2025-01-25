using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Services;

public interface IClassMapperService
{
    public Class Map(String className);
}