namespace MVC.NetTest.Models;

public class AddUserViewModel
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}