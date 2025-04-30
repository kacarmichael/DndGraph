using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Services.Interfaces;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.Services.Implementations;

public class ClassMapperService : IClassMapperService
{
    public Class Map(string className) => Constants.Classes[className];
}