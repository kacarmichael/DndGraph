using System.ComponentModel.DataAnnotations.Schema;
using Dnd.API.Models.Characters.Interfaces;
using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Models.Users.Implementations;

public class DomainUser : IDomainUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Username { get; set; }
    public List<ICharacter> Characters { get; set; }

    public DomainUser(string username)
    {
        Username = username;
        Characters = new List<ICharacter>();
    }
}