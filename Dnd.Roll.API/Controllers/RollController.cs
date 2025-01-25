using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.Roll.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RollController : ControllerBase
{
    private readonly IRollService _rollService;

    public RollController(IRollService rollService, IRollMapperService rollMapperService)
    {
        _rollService = rollService;
    }

    [HttpPost]
    public async Task<ActionResult<RollResponseDto>> PostRoll([FromBody] RollRequestDto req)
    {
        var response = await _rollService.Roll(req);
        return Ok(response);
    }
}