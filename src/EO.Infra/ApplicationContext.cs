using System.Reflection;
using EO.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EO.Infra
{
    public class ApplicationContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Tomador> Tomadores { get; set; }
        public DbSet<Tomador> Fornecedores { get; set; }
        public DbSet<Tomador> Enderecos { get; set; }
    }
}