using Company.DAL.Context;
using Company.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System_Management.Extensions;

namespace System_Management
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.GetAppService();
            //companydbcontext DI
            builder.Services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyConnection"));
            });
            //IdentityConnection DI
            builder.Services.AddDbContext<IdentityDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            //email settting DI
            builder.Services.Configure<EmailSetting>(
                builder.Configuration.GetSection("Email")
                );
      

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var companydbcontext = services.GetRequiredService<CompanyDbContext>();
                await companydbcontext.Database.MigrateAsync();

                var identitydbContext = services.GetRequiredService<IdentityDBContext>();
                await identitydbContext.Database.MigrateAsync();

            }
            catch(Exception ex)
            {
                var log = logger.CreateLogger<Program>();
                log.LogError(ex, "Error During Migration");

            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}