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
    public async Task<IActionResult> GetCharacters()                                                                                                                            
    {
        return Ok(await _context.Characters.ToListAsync());
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);
        return character == null ? NotFound() : Ok(character);                                          
    }
    
    [HttpPost]
    public async Task<ActionResult<CharacterResponseDto>> PostCharacter([FromBody] CharacterRequestDto req)
    {
        Character c = req.DtoToCharacter();
        _context.Characters.Add(c);
        await _context.SaveChangesAsync();
        CharacterResponseDto resp = new CharacterResponseDto(c);
        return Ok(resp);
    }
}