using System.ComponentModel.DataAnnotations;

namespace SQLInjection.API.DTOs;

public class LoginRequest
{
    [Required]
    [MaxLength(50)]
    public string Username {get;set;}  = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Password{get;set;} = string.Empty;
}