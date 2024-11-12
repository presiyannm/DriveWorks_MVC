using Microsoft.AspNetCore.Identity;

namespace DriveWorks_MVC.Data.SeedDb
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // List of predefined roles you want to create
            string[] roleNames = { "Admin", "User", "Manager" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
                }
            }
        }

        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            // Create a default admin user
            var adminUser = await userManager.FindByEmailAsync("admin@domain.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "admin@domain.com",
                    Email = "admin@domain.com"
                };
                var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");
                if (result.Succeeded)
                {
                    // Assign the Admin role to this user
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create a default regular user
            var regularUser = await userManager.FindByEmailAsync("user@domain.com");
            if (regularUser == null)
            {
                regularUser = new IdentityUser
                {
                    UserName = "user@domain.com",
                    Email = "user@domain.com"
                };
                var result = await userManager.CreateAsync(regularUser, "UserPassword123!");
                if (result.Succeeded)
                {
                    // Assign the User role to this user
                    await userManager.AddToRoleAsync(regularUser, "User");
                }
            }

            var managerUser = await userManager.FindByEmailAsync("manager@domain.com");
            if (managerUser == null)
            {
                managerUser = new IdentityUser
                { 
                    UserName = "manager@domain.com",
                    Email = "manager@domain.com"
                };

                var result = await userManager.CreateAsync(managerUser, "ManagerPassword123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(managerUser, "Manager");
                }

            }
        }

        public static async Task SeedDataAsync(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            await SeedRolesAsync(roleManager);

            // Seed users
            await SeedUsersAsync(userManager);
        }
    }

}
