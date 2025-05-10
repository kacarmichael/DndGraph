using Dnd.Application.Logging.Interfaces;
using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Main.Controllers;

[ApiController]
[Route("api/roll")]
public class RollController : ControllerBase
{
    private readonly IRollService _rollService;

    //private readonly ILogger _logger;
    private readonly ILoggingClient _logger;

    public RollController(IRollService rollService, ILogger<RollController> logger, ILoggingClient loggingClient)
    {
        _rollService = rollService;
        // _logger = logger;
        // _logger.LogInformation("Roll controller created");
        _logger = loggingClient;
        _logger.LogInformation("Roll controller created");
    }

    //[Authorize]
    [HttpPost]
    public async Task<ActionResult<RollResponseDto>> PostRoll([FromBody] RollRequestDto req)
    {
        var response = await _rollService.Roll(req);
        return Ok(response);
    }

    //[Authorize]
    [HttpPost("dice")]
    public Task<ActionResult<DiceRollResponseDto>> PostDiceRoll([FromBody] DiceRollRequestDto req)
    {
        try
        {
            _logger.LogInformation("POST /dice");
            _logger.LogInformation($"REQUEST: {req}");
            var res = _rollService.DiceRoll(req);
            _logger.LogInformation($"Roll service response: {res}");
            return Task.FromResult<ActionResult<DiceRollResponseDto>>(Ok(res));
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            return Task.FromResult<ActionResult<DiceRollResponseDto>>(BadRequest(ex.Message));
        }
    }

    //[Authorize]
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