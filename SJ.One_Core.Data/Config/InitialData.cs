﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SJ.One_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SJ.One_Core.Data.Config
{
    public class InitialData
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                User user = new User
                {
                    UserName = username,
                    Email = email
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
