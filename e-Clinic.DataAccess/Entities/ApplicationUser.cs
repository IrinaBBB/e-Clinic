using Microsoft.AspNetCore.Identity;

namespace e_Clinic.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Doctor? Doctor { get; set; } = null;
        public Patient? Patient { get; set; } = null;
        public StaffMember? StaffMember { get; set; } = null;
        public List<Appointment> Appointments { get; set; } = new();
    }
}

