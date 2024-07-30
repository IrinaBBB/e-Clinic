using e_Clinic.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_Clinic.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
                
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Billing> Billings => Set<Billing>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<StaffMember> StaffMembers => Set<StaffMember>();
    }
}
