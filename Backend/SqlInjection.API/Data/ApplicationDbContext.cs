using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using SQLInjection.API.Models;

namespace SQLInjection.API.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :base(options){}
    public DbSet<User> Users => Set<User>();
}