using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;
using SJ.One_Core.Data;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Service.Auth;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace SJ.One_Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SJOneContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            })
                .AddErrorDescriber<RuCustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<SJOneContext>();

            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            services.AddScoped<IAgeGroupRepository, AgeGroupRepository>();
            services.AddScoped<IAutoTimingRepository, AutoTimingRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IEventImageRepository, EventImageRepository>();
            services.AddScoped<IHandTimingRepository, HandTimingRepository>();
            services.AddScoped<ILocalityRepository, LocalityRepository>();
            services.AddScoped<IProtocolRepository, ProtocolRepository>();
            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ISportClubRepository, SportClubRepository>();
            services.AddScoped<ISportEventRepository, SportEventRepository>();
            services.AddScoped<IStartNumberRepository, StartNumberRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            InitialData.InitializeAsync(userManager, roleManager).Wait();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
