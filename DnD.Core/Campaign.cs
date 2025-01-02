using System.Collections;

namespace DnD.Core;

public class Campaign
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<User> Players { get; set; }

    public Campaign(int id, string name)
    {
        Id = id;
        Name = name;
        Players = new List<User>();
    }
}