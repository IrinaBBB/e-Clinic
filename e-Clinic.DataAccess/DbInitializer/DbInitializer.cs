using e_Clinic.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace e_Clinic.DataAccess.DbInitializer
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await RoleInitializer.InitializeRoles(context, userManager, roleManager);
        }
    }
}
