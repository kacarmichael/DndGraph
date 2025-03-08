using Dnd.Core.Main.Models.Rolls;
using Dnd.Core.Main.Utils;

namespace Dnd.Core.Main.Services;

public interface IRollMapperService
{
    public Task<IDiceRoll> Map(DtoBase req);
    public DtoBase Map(IDiceRoll roll);
}