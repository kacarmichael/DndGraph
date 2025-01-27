using Castle.Core.Logging;
using Dnd.Roll.API.Controllers;
using Dnd.Roll.API.DTOs;
using Dnd.Roll.API.Models.Characters;
using Dnd.Roll.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Dnd.Tests;

public class CharacterControllerTests
{
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
                    { "Warlock", 6}
                })
        };
        return characters;
    }

    public CharacterControllerTests()
    {
        _characterServiceMock = new Mock<ICharacterService>();
    }

    [Fact]
    public void GetCharacterList_ReturnsAllCharacters()
    {
        var characters = GetTestCharacters();
        _characterServiceMock.Setup(x => x.GetAllCharactersAsync()).ReturnsAsync(characters);

        var characterController = new CharacterController(_characterServiceMock.Object);

        var result = characterController.GetCharacters().Result.Value.Select(x => x.DtoToCharacter()).ToList();

        Assert.NotNull(result);
        Assert.Equal(GetTestCharacters().Count(), result.Count());
        Assert.True(characters.All(x => result.Any(y => Character.Compare(y, x))));
    }
    
    [Fact]
    public void GetCharacterById_ReturnsCharacter()
    {
        var character = GetTestCharacters().First();
        _characterServiceMock.Setup(x => x.GetCharacterAsync(It.IsAny<int>())).ReturnsAsync(character);
        var test = _characterServiceMock.Object.GetCharacterAsync(0);
        var characterController = new CharacterController(_characterServiceMock.Object);

        var result = characterController.GetCharacter(0);
        var result_conv = (CharacterResponseDto)((OkObjectResult)result.Result.Result).Value;
        var result_char = result_conv.DtoToCharacter();
        
        Assert.NotNull(result);
        Assert.True(character.Equals(result_char));
    }
}
