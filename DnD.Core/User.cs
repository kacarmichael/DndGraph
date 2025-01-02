namespace DnD.Core;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public User(int id, string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}