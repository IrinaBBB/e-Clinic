namespace e_Clinic.Models.ViewModels.PatientViewModels
{
    public class PatientListViewModel
    {
        public IEnumerable<DataAccess.Entities.Patient>? Patients { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
