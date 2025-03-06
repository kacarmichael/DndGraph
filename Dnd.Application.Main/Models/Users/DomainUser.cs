using System.ComponentModel.DataAnnotations.Schema;
using Dnd.Core.Main.Models.Characters;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Models.Users;

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