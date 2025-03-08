using Dnd.Application.Main.Utils;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Services;

namespace Dnd.Application.Main.Services;

public class ClassMapperService : IClassMapperService
{
    public IClass Map(string className) => Constants.Classes[className];
}