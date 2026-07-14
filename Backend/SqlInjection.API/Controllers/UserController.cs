using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLInjection.API.Data;
using SQLInjection.API.DTOs;
 
namespace SQLInjection.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public UserController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // OR 1=1-- is treated as text not executable SQL
        // It becomes WHERE Username = @__request_Username_0 (parameters)
        var user = await _db.Users.FirstOrDefaultAsync(
            u => u.Username == request.Username && u.Password == request.Password);

            if(user == null)
        {
            return Unauthorized(new
            {
                message = "Invalid username or password"
            });

            
        }
        return Ok(new {message = $"Welcome {user.Username}"});
        
    }
    [HttpPost("login-raw-safe")]
    public async Task<IActionResult> LoginRawSafe(LoginRequest request)
    { //FromSqlInterpolated allows use of raw sql queries
    // while parameterizing the variables to mitigate SQL Injection
        var user = await _db.Users.FromSqlInterpolated(
            $@"SELECT * FROM Users WHERE Username = {request.Username}
            AND Password = {request.Password}").FirstOrDefaultAsync();

            if(user == null)
        {
            return Unauthorized(new {message="Invalid Username or password"});
        }
        
        return Ok(new
        {
            message = $"Welcome {user.Username}"
        });
    }

}