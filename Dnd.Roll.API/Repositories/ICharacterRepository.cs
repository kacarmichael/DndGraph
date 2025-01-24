using Dnd.Roll.API.Models.Characters;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.Roll.API.Repositories;

public interface ICharacterRepository
{
    Task<IActionResult> GetAllCharacters();
    Character GetCharacter(int id);
    void AddCharacter(Character character);
    void UpdateCharacter(Character character);
    void DeleteCharacter(int id);
}