using Dnd.API.Models.Users.Interfaces;
using Dnd.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserAsync(string username) => Ok(await _userService.GetUserAsync(username));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserByIdAsync(int id) => Ok(await _userService.GetUserByIdAsync(id));

    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync() => Ok(await _userService.GetAllUsersAsync());

    [HttpPost]
    public async Task<IActionResult> AddUserAsync([FromBody] IDomainUser domainUser) =>
        Ok(await _userService.AddUserAsync(domainUser));

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync([FromBody] IDomainUser domainUser) =>
        Ok(await _userService.UpdateUserAsync(domainUser));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(await _userService.DeleteUserAsync(user));
    }
}