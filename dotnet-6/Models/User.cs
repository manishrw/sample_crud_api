namespace CrudApp.Models;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public User(long Id, string Email, string Name)
    {
        this.Id = Id;
        this.Email = Email;
        this.Name = Name;
    }

    public override string ToString()
        => $"User: {Id}, {Email}, {Name}";
}
