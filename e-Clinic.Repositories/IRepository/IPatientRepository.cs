using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;

namespace e_Clinic.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<bool> CreatePatient(CreatePatientViewModel patientViewModel);
        void Update(Patient patient);
    }
}