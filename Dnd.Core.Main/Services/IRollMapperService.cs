using Dnd.Core.Main.Models.Rolls;
using Dnd.Core.Main.Utils;

namespace Dnd.Core.Main.Services;

public interface IRollMapperService
{
    public Task<IDiceRoll> Map(IDto req);
    public IDto Map(IDiceRoll roll);
}