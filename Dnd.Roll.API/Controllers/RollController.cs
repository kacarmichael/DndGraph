using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.Roll.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RollController : ControllerBase
{
    private readonly RollDbContext _rollContext;

    private readonly CharacterDbContext _characterContext;
    
    
    public RollController(RollDbContext rollContext, CharacterDbContext characterContext)
    {
        _rollContext = rollContext;
        _characterContext = characterContext;
    }
    
    public Character IdToCharacter(int id) => _characterContext.Characters.FirstOrDefault(x => x.Id == id);
    
    [HttpPost]
    public async Task<ActionResult<RollResponseDto>> PostRoll([FromBody] RollRequestDto req)
    {
        Character character = IdToCharacter(req.CharacterId ?? 0);
        Roll roll = RollRequestDto.DtoToRoll(req, character);
        _rollContext.Rolls.Add(roll);
        await _rollContext.SaveChangesAsync();
        RollResponseDto resp = new RollResponseDto(roll);
        return Ok(resp);
    }
}