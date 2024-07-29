using AutoMapper;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.DoctorViewModels;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace e_Clinic.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorRepository(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public void Update(Doctor doctor)
        {
            var doctorFromDb = _db.Doctors.FirstOrDefault(p => p.Id == doctor.Id);
            if (doctorFromDb != null)
            {
                _mapper.Map(doctor, doctorFromDb);
            }
        }
    }
}