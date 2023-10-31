namespace e_Clinic.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        IVisitRepository Visits { get; }
        int Complete();
    }
}
