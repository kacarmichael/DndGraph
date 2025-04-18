using Dnd.Application.Main.DTOs;
using Dnd.Core.Main.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Main.Controllers;

[ApiController]
[Route("api/Characters")]
public class CharacterController : ControllerBase
{
    //private readonly DndDbContext _context;
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharacterResponseDto>>> GetCharacters()
    {
        var dtos = _characterService.GetAllCharactersAsync().Result;
        return Ok(dtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CharacterResponseDto>> GetCharacter(int id)
    {
        var character = await _characterService.GetCharacterAsync(id);
        var dto = new CharacterResponseDto(character);
        return character == null ? NotFound() : Ok((CharacterResponseDto)character);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponseDto>> PostCharacter([FromBody] CharacterRequestDto req)
    {
        // var chars = await _characterService.GetAllCharactersAsync();
        // if (chars != null)
        // {
        //     if (chars.Select(x => x.DtoToCharacter()).Contains(req.DtoToCharacter()))
        //         return BadRequest("Character name already exists");
        // }

        var c = _characterService.DtoToCharacter(req);
        c = await _characterService.AddCharacterAsync(c);
        c.Stats = _characterService.DtoToCharacterStats(req);
        c.Classes = _characterService.DtoToCharacterClasses(req, c.Id);
        CharacterResponseDto resp = new CharacterResponseDto(c);
        return Ok(resp);
    }
}