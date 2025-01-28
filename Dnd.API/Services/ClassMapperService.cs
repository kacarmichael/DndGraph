using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Services;

public class ClassMapperService : IClassMapperService
{
    public IClass Map(string className) => Constants.Classes[className];
}