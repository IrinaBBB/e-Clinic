namespace e_Clinic.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        int Complete();
    }
}
