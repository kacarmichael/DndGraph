using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Models.Rolls;
using Dnd.Roll.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RollController : ControllerBase
{
    private readonly IRollRepository _rollRepository;

    public RollController(IRollRepository rollRepository)
    {
        _rollRepository = rollRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<RollResponseDto>> PostRoll([FromBody] RollRequestDto req)
    {
        await _rollRepository.AddRoll(req);
        return NoContent();
    }
}