using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Characters;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Main.Controllers;

[ApiController]
[Route("api/Characters")]
public class CharacterController : ControllerBase
{
    //private readonly CharacterDbContext _context;
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharacterResponseDto>>> GetCharacters()
    {
        var chars = await _characterService.GetAllCharactersAsync();
        var converted = chars.Select(x => new CharacterResponseDto(character: x)).ToList();
        return Ok(converted);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CharacterResponseDto>> GetCharacter(int id)
    {
        var character = await _characterService.GetCharacterAsync(id);
        return character == null ? NotFound() : Ok(new CharacterResponseDto(character));
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponseDto>> PostCharacter([FromBody] CharacterRequestDto req)
    {
        var chars = (await GetCharacters()).Value;
        if (chars != null)
        {
            if (chars.Select(x => x.DtoToCharacter()).Contains(req.DtoToCharacter()))
                return BadRequest("Character name already exists");
        }

        Character c = req.DtoToCharacter();
        await _characterService.AddCharacterAsync(c);
        CharacterResponseDto resp = new CharacterResponseDto(c);
        return Ok(resp);
    }
}