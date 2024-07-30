using AutoMapper;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace e_Clinic.Repository
{
    public class StaffRepository : Repository<StaffMember>, IStaffRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public StaffRepository(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public void Update(StaffMember staff)
        {
            var staffFromDb = _db.StaffMembers.FirstOrDefault(p => p.Id == staff.Id);
            if (staffFromDb != null)
            {
                _mapper.Map(staff, staffFromDb);
            }
        }
    }
}
