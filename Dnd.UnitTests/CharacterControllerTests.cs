using Dnd.API.Main.Controllers;
using Dnd.Application.Main.DTOs;
using Dnd.Application.Main.Models.Characters;
using Dnd.Application.Main.Models.Characters.Stats;
using Dnd.Application.Main.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Dnd.UnitTests;

public class CharacterControllerTests
{
    private readonly Mock<ICharacterService> _characterServiceMock;
    private readonly List<Character> characters;
    private readonly Character character;
    public CharacterController characterController;

    private List<Character> GetTestCharacters()
    {
        var abilities = new AbilityBlock();
        var skills = new SkillBlock();
        var characters = new List<Character>()
        {
            new Character(
                name: "Theodred",
                //level: 6,
                stats: new CharacterStats(
                    level: 6,
                    abilities: abilities,
                    skills: skills
                ),
                //ac: 14,
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
        var result = characterController.GetCharacters().Result.Value;

        Assert.NotNull(result);
        Assert.Equal(characters.Count(), result.Count());
        Assert.True(characters.All(x => result.Any(y => Character.Compare(_characterServiceMock.Object.DtoToCharacter(y), x))));
    }

    [Fact]
    public void GetCharacterById_ReturnsCharacter()
    {
        var test = _characterServiceMock.Object.GetCharacterAsync(0);

        var result = characterController.GetCharacter(0).Result.Value;

        Assert.NotNull(result);
        Assert.True(character.Equals(result));
    }

    [Fact]
    public void PostCharacter_ReturnsRequest()
    {
        var result = characterController.PostCharacter(new CharacterRequestDto(character)).Result.Value;

        var result_conv = _characterServiceMock.Object.DtoToCharacter(result);

        Assert.NotNull(result);
        Assert.True(character.Equals(result_conv));
    }
}