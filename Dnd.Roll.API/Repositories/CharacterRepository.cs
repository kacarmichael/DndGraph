using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dnd.Roll.API.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _context;

    public CharacterRepository(CharacterDbContext context)
    {
        _context = context;
    }

    public async void AddCharacter(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    public async Task<IActionResult> GetAllCharacters()
    {
        //await _context.Characters.FirstOrDefaultAsync();
        return ok(await _context.Characters.ToListAsync());
    }

    public Character GetCharacter(int id) => _context.Characters.FirstOrDefault(x => x.Id == id);

    public void DeleteCharacter(int id) => _context.Characters.Remove(GetCharacter(id));

    public void UpdateCharacter(Character character) => _context.Characters.Update(character);
}