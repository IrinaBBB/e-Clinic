using e_Clinic.DataAccess.Entities;
using e_Clinic.DataAccess.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_Clinic.DataAccess.Db;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Visit> Visits { get; set; } = null!;
}

