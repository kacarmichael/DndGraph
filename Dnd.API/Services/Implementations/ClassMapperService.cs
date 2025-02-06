using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Services.Interfaces;

namespace Dnd.API.Services;

public class ClassMapperService : IClassMapperService
{
    public IClass Map(string className) => Constants.Classes[className];
}