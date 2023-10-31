using e_Clinic.Models.Patient;
using e_Clinic.Models.Visit;

namespace e_Clinic.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<ICollection<PatientViewModel>> GetPatientListAsync();
        Task<int> AddVisitToPatientAsync(VisitViewModel visitViewModel);
    }
}
