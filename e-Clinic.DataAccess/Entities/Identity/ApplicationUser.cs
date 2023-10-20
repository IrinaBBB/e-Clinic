using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    [MaxLength(225)]
    public string? FirstName { get; set; }

    [MaxLength(225)]
    public string? LastName { get; set; }
}

