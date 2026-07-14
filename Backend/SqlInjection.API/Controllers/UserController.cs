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
}