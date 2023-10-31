using e_Clinic.Models.Patient;
using e_Clinic.Models.Visit;

namespace e_Clinic.Repository.IRepository
{
    public interface IVisitRepository
    {
        Task<AddVisitViewModel?> AddVisitOnGetAsync(int patientId);
    }
}
