using e_Clinic.DataAccess.Entities;

namespace e_Clinic.Repository.IRepository
{
    public interface IStaffRepository : IRepository<StaffMember>
    {
        void Update(StaffMember staff);
    }
}
