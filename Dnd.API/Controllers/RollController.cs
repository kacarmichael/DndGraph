using Dnd.API.DTOs;
using Dnd.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Controllers;

[ApiController]
[Route("api/roll")]
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

    [HttpPost("dice")]
    public Task<ActionResult<DiceRollResponseDto>> PostDiceRoll([FromBody] DiceRollRequestDto req) =>
        Task.FromResult<ActionResult<DiceRollResponseDto>>(Ok(_rollService.DiceRoll(req)));

    [HttpPost("dice/simulate")]
    public Task<ActionResult<DiceSimulationResponseDto>> PostDiceSimulation([FromBody] DiceSimulationRequestDto req) =>
        Task.FromResult<ActionResult<DiceSimulationResponseDto>>(Ok(_rollService.Simulate(req)));
}