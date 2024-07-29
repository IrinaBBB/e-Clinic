using e_Clinic.DataAccess.Entities;

namespace e_Clinic.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient patient);
    }
}