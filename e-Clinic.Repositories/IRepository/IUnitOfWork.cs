namespace e_Clinic.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patient { get; }
        IDoctorRepository Doctor { get; }
        void Save();
    }
}


