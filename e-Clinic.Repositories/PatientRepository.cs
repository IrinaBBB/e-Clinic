using AutoMapper;
using e_Clinic.DataAccess.Db;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.Patient;
using e_Clinic.Models.Visit;
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

        public async Task<int> AddVisitToPatientAsync(VisitViewModel visitViewModel)
        {
            if (visitViewModel.PatientId == 0) return 0;
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == visitViewModel.PatientId);
            if (patient == null) return 0;
            if (patient.Visits != null)
            {
                patient.Visits.Add(_mapper.Map<Visit>(visitViewModel));
            } else
            {
                patient.Visits = new List<Visit>();
                patient.Visits.Add(_mapper.Map<Visit>(visitViewModel));
            }
            return await _db.SaveChangesAsync();
        }
    }
}
