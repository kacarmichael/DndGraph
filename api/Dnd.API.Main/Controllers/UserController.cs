using Dnd.Application.Main.Models.Users;
using Dnd.Application.Main.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.API.Main.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    //private readonly IUserMapperService _userMapperService;

    public UserController(IUserService userService)
    {
        _userService = userService;
        //_userMapperService = userMapperService;
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserAsync(string username) => Ok(await _userService.GetUserAsync(username));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserByIdAsync(int id) => Ok(await _userService.GetUserByIdAsync(id));

    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync() => Ok(await _userService.GetAllUsersAsync());

    [HttpPost]
    public async Task<IActionResult> AddUserAsync([FromBody] DomainUser domainUser) =>
        Ok(await _userService.AddUserAsync(domainUser));

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync([FromBody] DomainUser domainUser) =>
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