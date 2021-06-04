using System;
using EO.Application.AppServices;
using EO.Application.Interfaces;
using EO.Application.Mappings;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using EO.Infra;
using EO.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EO.UI.Extensions
{
    public static class DiConfiguration
    {
        public static void InjetarIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<Usuario>(options =>
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
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ITomadorAppService, TomadorAppService>();
            services.AddScoped<IFornecedorAppService, FornecedorAppService>();
            services.AddScoped<ISolicitacaoEmprestimoAppService, SolicitacaoEmprestimoAppService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITomadorRepository, TomadorRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<ISolicitacaoEmprestimoRepository, SolicitacaoEmprestimoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton(new AutoMapperConfig().GetMapperConfig().CreateMapper());
        }
    }
}