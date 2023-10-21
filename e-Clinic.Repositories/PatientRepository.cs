using AutoMapper;
using e_Clinic.DataAccess.Db;
using e_Clinic.Models.Patient;
using e_Clinic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace e_Clinic.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public PatientRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ICollection<PatientViewModel>> GetPatientListAsync()
        {
            var patients = _mapper.Map<ICollection<PatientViewModel>>(await _db.Patients.ToListAsync());
            return patients;
        }
    }
}
