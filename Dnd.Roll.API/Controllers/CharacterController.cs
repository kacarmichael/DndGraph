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
    public async Task<IActionResult> PostCharacter([FromBody] Character character)
    {
        _context.Add(character);
        await _context.SaveChangesAsync();
        return Ok(character);
    }
}