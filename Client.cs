using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Client : IdentityUser
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    public decimal Balance { get; set; } = 0;

    // Identity przechowuje role jako stringi
    public ICollection<IdentityUserRole<string>> Roles { get; set; } = new List<IdentityUserRole<string>>();
}
