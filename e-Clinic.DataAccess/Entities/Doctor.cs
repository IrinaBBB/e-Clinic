using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities
{
    public class Doctor : BaseUser
    {
        [Required]
        public string? LicenseNumber { get; set; } 

        [Required]
        public DateTime JoiningDate { get; set; } = DateTime.Now;

        [Required]
        public string? Specialty { get; set; }

        public List<Appointment>? Appointments { get; set; } = new();
    }
}
