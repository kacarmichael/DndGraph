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
    //private readonly IRollMapperService _rollMapperService;

    public RollController(IRollService rollService, IRollMapperService rollMapperService)
    {
        _rollService = rollService;
        //_rollMapperService = rollMapperService;
    }
    
    [HttpPost]
    public async Task<ActionResult<RollResponseDto>> PostRoll([FromBody] RollRequestDto req)
    {
        //var roll = _rollMapperService.Map(req); //The mapping process instantiates the roll object, which actually performs the roll
        return Ok(_rollService.Roll(req));

    }
}