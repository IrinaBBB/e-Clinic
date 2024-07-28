using e_Clinic.DataAccess.Entities;
using e_Clinic.Utility;
using Microsoft.AspNetCore.Identity;

namespace e_Clinic.DataAccess.DbInitializer
{
    public class RoleInitializer
    {
        public static async Task InitializeRoles(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Define the roles you want to create
            string[] roleNames = { ClinicConstants.ROLE_ADMIN, ClinicConstants.ROLE_MANAGER, ClinicConstants.ROLE_DOCTOR, ClinicConstants.ROLE_PATIENT };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the roles and seed them to the database
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
