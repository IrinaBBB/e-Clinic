using AutoMapper;
using e_Clinic.DataAccess.Db;
using e_Clinic.Repository.IRepository;

namespace e_Clinic.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Patients = new PatientRepository(context, mapper);
        }

        public IPatientRepository Patients { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
