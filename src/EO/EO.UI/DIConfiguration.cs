using System;
using EO.Domain.Entities;
using EO.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace EO.UI
{
    public static class DiConfiguration
    {
        public static void InjectIdentity(this IServiceCollection services)
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
            });
        }
    }
}