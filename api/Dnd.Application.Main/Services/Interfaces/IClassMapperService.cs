using Dnd.Application.Main.Models.Characters;

namespace Dnd.Application.Main.Services.Interfaces;

public interface IClassMapperService
{
    public Class Map(string className);
}