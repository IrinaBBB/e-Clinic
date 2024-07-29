using e_Clinic.DataAccess.Entities;

namespace e_Clinic.Repository.IRepository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor doctor);
    }
}
