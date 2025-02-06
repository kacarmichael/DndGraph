using Dnd.API.DTOs;
using Dnd.API.Models.Rolls.Interfaces;

namespace Dnd.API.Services;

public interface IRollMapperService
{
    public Task<IDiceRoll> Map(RollRequestDto req);
    public RollResponseDto Map(IDiceRoll roll);
}