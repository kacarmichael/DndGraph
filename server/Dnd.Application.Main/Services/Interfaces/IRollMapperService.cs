using Dnd.Application.Main.Models.Rolls;
using Dnd.Application.Main.Utils;

namespace Dnd.Application.Main.Services.Interfaces;

public interface IRollMapperService
{
    public Task<DiceRollBase> Map(IDto req);
    public IDto Map(DiceRollBase roll);
}