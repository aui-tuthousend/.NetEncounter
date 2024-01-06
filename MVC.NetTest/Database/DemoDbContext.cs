
using Microsoft.EntityFrameworkCore;
using MVC.NetTest.Models.Domain;

namespace MVC.NetTest.Database;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}