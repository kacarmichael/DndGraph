using Dnd.API.Controllers;
using Dnd.API.DTOs;
using Dnd.API.Models.Characters;
using Dnd.API.Models.Rolls;
using Dnd.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Dnd.Tests;

public class RollControllerTests
{
    private readonly Mock<IRollService> _rollServiceMock;
    private readonly Mock<IRollMapperService> _rollMapperMock;
    private readonly Mock<ICharacterService> _characterServiceMock;

    private List<Character> GetTestCharacters()
    {
        var characters = new List<Character>()
        {
            new Character(
                name: "Theodred",
                level: 6,
                stats: new CharacterStats(
                    strength: 10,
                    dexterity: 10,
                    intelligence: 10,
                    constitution: 10,
                    wisdom: 10,
                    charisma: 10,
                    acrobatics: 0,
                    animalHandling: 0,
                    arcana: 0,
                    athletics: 0,
                    deception: 0,
                    history: 0,
                    insight: 0,
                    intimidation: 0,
                    investigation: 0,
                    medicine: 0,
                    nature: 0,
                    perception: 0,
                    performance: 0,
                    persuasion: 0,
                    religion: 0,
                    sleightOfHand: 0,
                    stealth: 0,
                    survival: 0,
                    proficiencies: new List<string>()
                    {
                        "Arcana"
                    }),
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
            numDice: 2,
            numSides: 6,
            classUsed: null);
    }

    public DiceRollBase GetTestDiceRoll()
    {
        return new MeleeAttackRoll(character: GetTestCharacters().First());
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
    }

    [Fact]
    public void PostRoll()
    {
        var roll = GetTestRollRequestDto();
        _rollServiceMock.Setup(x => x.Roll(It.IsAny<RollRequestDto>())).ReturnsAsync(GetTestRollResponseDto());
        _rollMapperMock.Setup(x => x.Map(It.IsAny<RollRequestDto>())).ReturnsAsync(GetTestDiceRoll());
        var rollController = new RollController(_rollServiceMock.Object, _rollMapperMock.Object);
        var response = rollController.PostRoll(roll);
        var result = (RollResponseDto)((OkObjectResult)response.Result.Result).Value;

        Assert.NotNull(result);
        Assert.IsType<int>(result.RollValue);
    }
}