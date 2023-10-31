using AutoMapper;
using e_Clinic.DataAccess.Db;
using e_Clinic.Models.Patient;
using e_Clinic.Models.Visit;
using e_Clinic.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace e_Clinic.Repository
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public VisitRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<AddVisitViewModel?> AddVisitOnGetAsync(int patientId)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
            if (patient == null) return null;
            var addVisitViewModel = new AddVisitViewModel
            {
                PatientViewModel = _mapper.Map<PatientViewModel>(patient),
                VisitViewModel = new VisitViewModel()
            };
            return addVisitViewModel;
        }
    }
}
