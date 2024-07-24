using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities
{
    public class Patient : BaseUser
    {
        public string? EmergencyContact { get; set; }
        public List<Appointment>? Appointments { get; set; } = new();
    }
}
