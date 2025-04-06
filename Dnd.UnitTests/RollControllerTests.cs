using Dnd.API.Main.Controllers;
using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Models.Dice;
using Dnd.Application.Main.Models.Rolls;
using Dnd.Core.Logging;
using Dnd.Core.Main.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Dnd.UnitTests;

public class RollControllerTests
{
    private readonly Mock<IRollService> _rollServiceMock;
    private readonly Mock<IRollMapperService> _rollMapperMock;
    private readonly Mock<ICharacterService> _characterServiceMock;
    private readonly Mock<ILogger<RollController>> _loggerMock;
    private readonly Mock<ILoggingClient> _loggingClientMock;
    public RollController rollController;

    private List<Character> GetTestCharacters()
    {
        var abilities = new AbilityBlock();
        var skills = new SkillBlock();
        var characters = new List<Character>()
        {
            new Character(
                name: "Theodred",
                level: 6,
                stats: new CharacterStats(
                    level: 6,
                    abilities: abilities,
                    skills: skills),
                ac: 14,
                charClass: new Dictionary<string, int>()
                {
                    { "Warlock", 6 }
                })
        };
        return characters;
    }

    public RollRequestDto GetTestRollRequestDto()
    {
        return new RollRequestDto(
            rollType: "attackRollMelee",
            ability: null,
            characterId: 0,
            modifier: 4,
            new DiceSet(d6: 2),
            classUsed: null);
    }

    public DiceRollBase GetTestDiceRoll()
    {
        return new MeleeAttackRoll(character: GetTestCharacters().First(), new DiceSet(1, 20));
    }

    public RollResponseDto GetTestRollResponseDto()
    {
        return new RollResponseDto(Roll: GetTestDiceRoll());
    }

    public RollControllerTests()
    {
        _rollServiceMock = new Mock<IRollService>();
        _rollMapperMock = new Mock<IRollMapperService>();
        _characterServiceMock = new Mock<ICharacterService>();
        _loggerMock = new Mock<ILogger<RollController>>();
        _loggingClientMock = new Mock<ILoggingClient>();
        _rollServiceMock.Setup(x => x.Roll(It.IsAny<RollRequestDto>())).ReturnsAsync(GetTestRollResponseDto());
        _rollMapperMock.Setup(x => x.Map(It.IsAny<RollRequestDto>())).ReturnsAsync(GetTestDiceRoll());
        rollController = new RollController(_rollServiceMock.Object, _loggerMock.Object, _loggingClientMock.Object);
    }

    [Fact]
    public void PostRoll()
    {
        var roll = GetTestRollRequestDto();


        var response = rollController.PostRoll(roll);
        var result = (RollResponseDto)((OkObjectResult)response.Result.Result).Value;

        Assert.NotNull(result);
        Assert.IsType<int>(result.RollValue);
    }
}