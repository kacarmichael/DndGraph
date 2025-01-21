using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RollController : ControllerBase
{
    private readonly IRollService _rollService;

    public RollController(IRollService rollService)
    {
        _rollService = rollService;
    }
    
    [HttpPost]
    public async Task<ActionResult<RollResponseDto>> PostRoll([FromBody] RollRequestDto req)
    {
        //await _rollRepository.AddRoll(req);
        return NoContent();
    }
}