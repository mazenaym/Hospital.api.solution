using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Seeder
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "Doctor", "Nurse", "Patient", "Reception", "HR" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedAdminUserAsync(UserManager<Appuser> userManager)
        {
            string adminEmail = "admin@system.com";
            string adminPassword = "Admin@123"; // 🔒 غيّره في الإنتاج!

            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);

            if (existingAdmin == null)
            {
                var adminUser = new Appuser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    fullname = "System Administrator",
                    age = 35,
                    gender = "Other",
                    usertype = "Admin"
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
        public static async Task AssignRolesToExistingUsersAsync(UserManager<Appuser> userManager)
        {
            var users = userManager.Users.ToList();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (!roles.Any() && !string.IsNullOrWhiteSpace(user.usertype))
                {
                    await userManager.AddToRoleAsync(user, user.usertype);
                }
            }
        }
    }
}

