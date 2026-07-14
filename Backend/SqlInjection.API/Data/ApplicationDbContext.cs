using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using SQLInjection.API.Models;

namespace SQLInjection.API.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :base(options){}
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "Ahmed",
                Password = "12345"
            },
            new User
            {
                Id = 2,
                Username = "Ahmed Raza",
                Password = "12346"
            },
            new User
            {
                Id = 3,
                Username = "Ahmed Khan",
                Password = "12347"
            }

        );
    }
}