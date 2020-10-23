using Microsoft.AspNetCore.Identity;
using SJ.One_Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SJ.One_Core.Data
{
    public class InitialData
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            string username = "admin";
            string email = "adm@sjone.com";
            string password = "*Aa123";

            if (await userManager.FindByNameAsync(username) == null)
            {
                string[] roles = new string[] { "User", "Admin", "Manager", "Judge", "JudgeAssist", "Trainer" };

                foreach (var role in roles)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole<int>(role));
                    }
                }

                User user = new User
                {
                    UserName = username,
                    Email = email,
                    RegistrationDate = DateTime.Now.Date
                };

                IdentityResult result = await userManager
                    .CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }            
        }

    }
}
