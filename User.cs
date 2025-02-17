using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
public class User:IdentityUser
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Fullname { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
}
