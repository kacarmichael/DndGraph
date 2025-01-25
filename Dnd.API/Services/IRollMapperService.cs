using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Rolls;

namespace Dnd.Roll.API.Services;

public interface IRollMapperService
{
    public Task<DiceRollBase> Map(RollRequestDto req);
    public RollResponseDto Map(DiceRollBase roll);
}