using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities
{
    public class Prescription
    {
        public int Id { get; set; }

        [Required]
        public string? MedicationName { get; set; }

        [Required]
        public string? Dosage { get; set; }

        [Required]
        public string? Duration { get; set; }

        [Required]
        public string? Instructions { get; set; }

        public int? RecordId { get; set; }
        public MedicalRecord? MedicalRecord { get; set; }
    }
}
