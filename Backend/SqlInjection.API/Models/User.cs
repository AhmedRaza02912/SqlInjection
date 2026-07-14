using System.ComponentModel.DataAnnotations;

namespace SQLInjection.API.Models;

public class User
{
    public int Id{get;set;}
    [MaxLength(50)]
    public string Username {get;set;} = string.Empty;
    
    [MaxLength(100)]
    public string Password{get;set;} = string.Empty;
}