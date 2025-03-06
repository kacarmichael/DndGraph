using Dnd.API.Main.DTOs;
using Dnd.Core.Main.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Main.Controllers;

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

    [Authorize]
    [HttpGet("secretping")]
    public string AuthTest() => "Secret Pong";

    [HttpGet("classes")]
    public Task<IEnumerable<ClassResponseDto>> GetClasses() =>
        Task.FromResult(_characterService.GetAllClasses().Select(x => new ClassResponseDto(x)).AsEnumerable());
}