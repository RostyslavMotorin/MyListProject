using Microsoft.AspNetCore.Identity;
using MyList.Domain.Common.Models;

namespace MyList.Domain.Services
{
    public class RoleInitializerService
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole() { Name = "admin" });
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole() { Name = "user" });
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser
                { Email = adminEmail, UserName = adminEmail, FirstName = String.Empty };
                IdentityResult result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
