using Dnd.API.DTOs;
using Dnd.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Controllers;

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

    [HttpPost("/dice")]
    public async Task<ActionResult<DiceRollResponseDto>> PostDiceRoll([FromBody] DiceRollRequestDto req) =>
        Ok(await _rollService.DiceRoll(req));>
}