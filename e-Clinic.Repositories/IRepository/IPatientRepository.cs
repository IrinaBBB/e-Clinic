using e_Clinic.Models.Patient;

namespace e_Clinic.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<ICollection<PatientViewModel>> GetPatientListAsync();
    }
}
