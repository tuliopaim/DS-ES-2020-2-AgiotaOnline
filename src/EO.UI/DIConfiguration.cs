using System;
using EO.Application.AppServices;
using EO.Application.Interfaces;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using EO.Infra;
using EO.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EO.UI
{
    public static class DiConfiguration
    {
        public static void InjetarIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
            })
            .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAuthentication().Services.ConfigureApplicationCookie(options =>
            {
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(6);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });
        }

        public static void InjetarServicos(this IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ITomadorAppService, TomadorAppService>();
            services.AddScoped<IFornecedorAppService, FornecedorAppService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITomadorRepository, TomadorRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}