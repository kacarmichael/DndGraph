using Dnd.Application.Main.DTOs;
using Dnd.Core.Main.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Main.Controllers;

[Authorize]
[ApiController]
[Route("api/roll")]
public class RollController : ControllerBase
{
    private readonly IRollService _rollService;
    private readonly ILogger _logger;

    public RollController(IRollService rollService, ILogger<RollController> logger)
    {
        _rollService = rollService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<RollResponseDto>> PostRoll([FromBody] RollRequestDto req)
    {
        var response = await _rollService.Roll(req);
        return Ok(response);
    }

    [HttpPost("dice")]
    public Task<ActionResult<DiceRollResponseDto>> PostDiceRoll([FromBody] DiceRollRequestDto req)
    {
        _logger.LogInformation("POST /dice");
        _logger.LogInformation($"REQUEST: {req}");
        var res = _rollService.DiceRoll(req);
        _logger.LogInformation($"Roll service response: {res}");
        return Task.FromResult<ActionResult<DiceRollResponseDto>>(Ok(res));
    }


    [HttpPost("dice/simulate")]
    public Task<ActionResult<DiceSimulationResponseDto>> PostDiceSimulation([FromBody] DiceSimulationRequestDto req)
    {
        _logger.LogInformation("POST /dice/simulate");
        _logger.LogInformation($"REQUEST: {req}");
        var res = _rollService.Simulate(req);
        _logger.LogInformation($"Roll service response: {res}");
        return Task.FromResult<ActionResult<DiceSimulationResponseDto>>(Ok(res));
    }
}