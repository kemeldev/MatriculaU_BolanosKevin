using MatriculaU_BolanosKevin.Models;
using Microsoft.AspNetCore.Identity;

namespace MatriculaU_BolanosKevin.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdmin(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create roles if they don’t exist
            string[] roleNames = { "Admin", "Professor", "Student" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a default Admin user
            if (await userManager.FindByEmailAsync("admin@university.com") == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@university.com",
                    Email = "admin@university.com",
                    FullName = "System Administrator",
                    EmailConfirmed = true
                };

                string adminPassword = "Admin@123";  // Change as needed
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}