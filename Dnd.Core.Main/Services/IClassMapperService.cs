using Dnd.Core.Main.Models.Characters;

namespace Dnd.Core.Main.Services;

public interface IClassMapperService
{
    public IClass Map(String className);
}