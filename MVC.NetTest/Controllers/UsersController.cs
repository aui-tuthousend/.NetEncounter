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

    [HttpGet]
    public async Task<IActionResult> View(Guid id)
    {
        var usr = await _demoDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (usr != null)
        {
            var viewModel = new UpdateUserViewModel()
            {
                Id = usr.Id,
                Email = usr.Email,
                Name = usr.Name,
                BirthDate = usr.BirthDate,
            };
        
            return await Task.Run((() =>View("View", viewModel) ));
        }
        return Redirect("/");
    }

    [HttpPost]
    public async Task<IActionResult> View(UpdateUserViewModel model)
    {
        var usr = await _demoDbContext.Users.FindAsync(model.Id);
        if (usr!=null)
        {
            usr.Email = model.Email;
            usr.Name = model.Name;
            usr.BirthDate = model.BirthDate;

            await _demoDbContext.SaveChangesAsync();
            return Redirect("/Users");
        }
        
        return Redirect("/");
    }

}