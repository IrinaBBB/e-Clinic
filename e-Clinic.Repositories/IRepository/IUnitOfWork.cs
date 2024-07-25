namespace e_Clinic.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patient { get; }
        void Save();
    }
}

