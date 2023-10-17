using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(255)]
        public string? FirstName { get; set; }

        [PersonalData]
        [MaxLength(255)]
        public string? LastName { get; set; } 
    }
}
