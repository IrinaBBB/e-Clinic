using e_Clinic.Models.Patient;

namespace e_Clinic.Models.Visit
{
    public class AddVisitViewModel
    {
        public PatientViewModel PatientViewModel { get; set; } = null!;
        public VisitViewModel VisitViewModel { get; set; } = null!;
    }
}
