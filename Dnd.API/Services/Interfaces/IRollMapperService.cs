using Dnd.API.DTOs;
using Dnd.API.Models.Rolls.Interfaces;

namespace Dnd.API.Services.Interfaces;

public interface IRollMapperService
{
    public Task<IDiceRoll> Map(RollRequestDto req);
    public RollResponseDto Map(IDiceRoll roll);
}