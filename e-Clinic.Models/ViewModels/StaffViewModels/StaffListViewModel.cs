namespace e_Clinic.Models.ViewModels.PatientViewModels
{
    public class StaffListViewModel
    {
        public IEnumerable<DataAccess.Entities.StaffMember>? StaffMembers { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
