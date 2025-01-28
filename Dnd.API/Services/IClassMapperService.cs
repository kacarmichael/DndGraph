using Dnd.API.Models.Characters;
using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Services;

public interface IClassMapperService
{
    public IClass Map(String className);
}