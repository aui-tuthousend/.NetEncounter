namespace MVC.NetTest.Models;

public class UpdateUserViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}