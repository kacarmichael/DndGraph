using Dnd.Roll.API.Controllers;
using Dnd.Roll.API.Infrastructure;
using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Dnd.Tests;

public class CharacterControllerTests
{
    [Fact]
    public async Task GetCharacter_ReturnsOk_WithCharacter()
    {
        var characterId = 1;
        var character = new Character("Test Character", 1, new CharacterStats(), 10, new Dictionary<string, int>());
        var characterRepositoryMock = new Mock<ICharacterRepository>();
        var characterDbContextMock = new Mock<CharacterDbContext>();
        characterRepositoryMock.Setup(x => x.GetCharacterAsync(characterId)).ReturnsAsync(character);

        var controller = new CharacterController(characterDbContextMock.Object);

        var result = await controller.GetCharacter(characterId);

        var okResult = result as OkObjectResult;

        Assert.NotNull(okResult);
        Assert.Equal(character, okResult.Value);
    }
}