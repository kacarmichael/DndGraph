using Dnd.API.DTOs;
using Dnd.API.Services;
using Dnd.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Controllers;

[Route("api/public")]
[ApiController]
public class PublicController : ControllerBase
{
    private readonly IRollService _rollService;
    private readonly ICharacterService _characterService;

    public PublicController(IRollService rollService, ICharacterService characterService)
    {
        _rollService = rollService;
        _characterService = characterService;
    }

    [HttpGet("ping")]
    public string Ping() => "pong";

    [HttpGet("classes")]
    public Task<IEnumerable<ClassResponseDto>> GetClasses() =>
        Task.FromResult(_characterService.GetAllClasses().Select(x => new ClassResponseDto(x)).AsEnumerable());
}