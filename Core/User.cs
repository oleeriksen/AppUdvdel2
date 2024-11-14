namespace Core;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "NO NAME";

    public string Password { get; set; } = "qwerty";

    public Role Role { get; set; }

}