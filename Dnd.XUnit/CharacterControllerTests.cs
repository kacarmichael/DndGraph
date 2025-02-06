using Dnd.API.Controllers;
using Dnd.API.DTOs;
using Dnd.API.Models.Characters.Implementations;
using Dnd.API.Services;
using Dnd.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace dnd.xunit2;

public class CharacterControllerTests
{
    private readonly Mock<ICharacterService> _characterServiceMock;
    private readonly List<Character> characters;
    private readonly Character character;
    public CharacterController characterController;

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

    public CharacterControllerTests()
    {
        _characterServiceMock = new Mock<ICharacterService>();
        characters = GetTestCharacters();
        _characterServiceMock.Setup(x => x.GetAllCharactersAsync()).ReturnsAsync(characters);
        character = GetTestCharacters().First();
        _characterServiceMock.Setup(x => x.GetCharacterAsync(It.IsAny<int>())).ReturnsAsync(character);
        _characterServiceMock.Setup(x => x.AddCharacterAsync(It.IsAny<Character>())).ReturnsAsync(character);
        characterController = new CharacterController(_characterServiceMock.Object);
    }

    [Fact]
    public void GetCharacterList_ReturnsAllCharacters()
    {
        var characterController = new CharacterController(_characterServiceMock.Object);

        var result = characterController.GetCharacters();
        var conv = ((OkObjectResult)result.Result.Result).Value;
        var list = (conv as IEnumerable<CharacterResponseDto>).Select(x => x.DtoToCharacter()).ToList();

        Assert.NotNull(result);
        Assert.Equal(characters.Count(), list.Count());
        Assert.True(characters.All(x => list.Any(y => Character.Compare(y, x))));
    }

    [Fact]
    public void GetCharacterById_ReturnsCharacter()
    {
        var test = _characterServiceMock.Object.GetCharacterAsync(0);
        var characterController = new CharacterController(_characterServiceMock.Object);

        var result = characterController.GetCharacter(0);
        var result_conv = (CharacterResponseDto)((OkObjectResult)result.Result.Result).Value;
        var result_char = result_conv.DtoToCharacter();

        Assert.NotNull(result);
        Assert.True(character.Equals(result_char));
    }

    [Fact]
    public void PostCharacter_ReturnsRequest()
    {
        var result = characterController.PostCharacter(new CharacterRequestDto(character));

        var result_conv = ((CharacterResponseDto)((OkObjectResult)result.Result.Result).Value).DtoToCharacter();

        Assert.NotNull(result);
        Assert.True(character.Equals(result_conv));
    }
}