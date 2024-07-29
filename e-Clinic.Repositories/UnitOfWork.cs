using AutoMapper;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace e_Clinic.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            Patient = new PatientRepository(_context, _mapper, _userManager);
            Doctor = new DoctorRepository(_context, _mapper, _userManager);
        }

        public IPatientRepository Patient { get; private set; }
        public IDoctorRepository Doctor { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
