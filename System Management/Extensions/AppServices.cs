using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Context;
using Company.DAL.Entities.identity;
using Microsoft.AspNetCore.Identity;
using System_Management.Helpers;

namespace System_Management.Extensions
{
    public static class AppServices
    {
        public static IServiceCollection GetAppService(this IServiceCollection Services)
        {
            // Add services to the container.
            Services.AddControllersWithViews();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddAutoMapper(typeof(ProfileMapping));
            Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            Services.AddScoped<IEmailServic, EmailServic>();
            Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<IdentityDBContext>().AddDefaultTokenProviders();
            Services.AddAuthentication();


            return Services;
        }
    }
}
