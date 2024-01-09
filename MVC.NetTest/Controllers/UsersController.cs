using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.NetTest.Database;
using MVC.NetTest.Models;
using MVC.NetTest.Models.Domain;

namespace MVC.NetTest.Controllers;

public class UsersController : Controller
{
    private readonly DemoDbContext _demoDbContext;
    public UsersController(DemoDbContext data)
    {
        this._demoDbContext = data;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await this._demoDbContext.Users.ToListAsync();
        return View(users);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddUserViewModel user)
    {
        var usr = new User()
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Email = user.Email,
            BirthDate = user.BirthDate,
        };

        await _demoDbContext.Users.AddAsync(usr);
        await _demoDbContext.SaveChangesAsync();

        return Redirect("/");
    }
}