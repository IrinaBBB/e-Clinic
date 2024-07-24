using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities
{
    public class StaffMember : BaseUser
    {
        [Required]
        public string? Role { get; set; } 
        public DateTime JoiningDate { get; set; } = DateTime.Now;
    }
}
