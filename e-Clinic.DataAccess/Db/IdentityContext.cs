using e_Clinic.DataAccess.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_Clinic.DataAccess.Db
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {     
        public DbSet<ApplicationUser> IdentityUsers { get; set; } = null!;
    }
}
    
