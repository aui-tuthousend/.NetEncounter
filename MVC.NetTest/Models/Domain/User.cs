namespace MVC.NetTest.Models.Domain;
using System;
using System.ComponentModel.DataAnnotations;
public class User
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(maximumLength: int.MaxValue, MinimumLength = 8, ErrorMessage = "Name must be at least 8 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}
