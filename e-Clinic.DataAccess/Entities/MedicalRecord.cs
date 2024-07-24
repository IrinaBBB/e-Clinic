namespace e_Clinic.DataAccess.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }

        public DateTime DateOfVisit { get; set; }

        public string? Diagnosis { get; set; }

        public string? Treatment { get; set; }

        public string? Notes { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public List<Prescription>? Prescriptions { get; set; }
    }
}
