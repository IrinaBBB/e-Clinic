namespace e_Clinic.Models.ViewModels.DoctorViewModels
{
    public class DoctorListViewModel
    {
        public IEnumerable<DataAccess.Entities.Doctor>? Doctors { get; set; } = new List<DataAccess.Entities.Doctor>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
