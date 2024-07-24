using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Clinic.DataAccess.Entities
{
    public class Billing
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime? PaymentDate { get; set; }

        [Required]
        public string? PaymentMethod { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
