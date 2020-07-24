using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SJ.One_Core.Models;
using System;
using System.Threading.Tasks;

namespace SJ.One_Core.Data.Config
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public static async Task InitialData(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            

            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];           

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
