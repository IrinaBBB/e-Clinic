using AutoMapper;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace e_Clinic.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientRepository(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager) : base(db)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> CreatePatientAsync(CreatePatientViewModel patientViewModel)
        {
            var newPatientUser = new ApplicationUser
            {
                Email = patientViewModel.Email,
                UserName = patientViewModel.Email,
                Patient = _mapper.Map<Patient>(patientViewModel)
            };


            if (patientViewModel?.Password is not null)
            {
                try
                {
                    var result = await _userManager.CreateAsync(newPatientUser, patientViewModel.Password);
                    _db.SaveChanges();
                    return result.Succeeded;
                } catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
            return false;
        }

        public async Task<bool> RemovePatientWithIdentityUserAsync(int id)
        {
            var patient = _db.Patients.Include(p => p.ApplicationUser).FirstOrDefault(p => p.Id == id);
            if (patient != null && patient.ApplicationUser != null) 
            {
                try
                {
                    await _userManager.DeleteAsync(patient.ApplicationUser);
                    _db.Patients.Remove(patient);
                    _db.SaveChanges();
                    return true;
                } catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return false;
                }
            }
            return false;
        }

        public void Update(Patient patient)
        {
            var patientFromDb = _db.Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (patientFromDb != null)
            {
                _mapper.Map(patient, patientFromDb);
            }
        }
    }
}
