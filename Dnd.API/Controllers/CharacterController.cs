using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Controllers;

[ApiController]
[Route("api/Characters")]
public class CharacterController : ControllerBase
{
    private readonly CharacterDbContext _context;

    public CharacterController(CharacterDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharacterResponseDto>>> GetCharacters()
    {
        var chars = await _context.Characters.ToListAsync();
        return chars.Select(x => new CharacterResponseDto(x)).ToList();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CharacterResponseDto>> GetCharacter(int id)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);
        return character == null ? NotFound() : Ok(new CharacterResponseDto(character));
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponseDto>> PostCharacter([FromBody] CharacterRequestDto req)
    {
        if (await _context.Characters.FirstOrDefaultAsync(x => x.Name == req.Name) != null)
            return BadRequest("Character name already exists");
        Character c = req.DtoToCharacter();
        _context.Characters.Add(c);
        await _context.SaveChangesAsync();
        CharacterResponseDto resp = new CharacterResponseDto(c);
        return Ok(resp);
    }
}