using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public TimeSpan? AppointmentTime { get; set; }

        public string? Reason { get; set; }

        public string? Status { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public Billing? Billing { get; set; } = null;
    }
}