using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Services.Interfaces;

public interface IClassMapperService
{
    public IClass Map(String className);
}