using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GamesKey;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GamesKey.Services;
using GamesKey.Data.Identity;
using GamesKey.Middleware;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsetings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsetings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<GamesKeyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GamesKeyDbConnectionString")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<GamesKeyDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication();

            services.AddTransient<IGamesService, GamesService>();
            services.AddTransient<IPicturesService, PicturesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GamesKeyDbContext dbcontext, UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Returns the angular index.html if a page is not found.
            app.UseMiddleware<NotFoundMiddleware>(env);

            // Cors configuration
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials().Build());

            // Serves the angular Index.html from wwwroot
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            dbcontext.Database.Migrate();

            if (env.IsDevelopment())
            {
                using (userManager)
                {
                    if (!userManager.Users.Any())
                    {
                        userManager.CreateAsync(new ApplicationUser { UserName = "eksempel@mailinator.com", Email = "eksempel@mailinator.com", EmailConfirmed = true }, "Password123!");
                    }
                }
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
