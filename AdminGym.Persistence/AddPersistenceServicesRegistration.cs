using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using AdminGym.Persistence.DbContexts;
using AdminGym.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminGym.Persistence
{
    public static class AddPersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddDbContext<ApplicationDbEFContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbEFContext).Assembly.FullName)));

            services.AddIdentity<User, Role>()
             .AddEntityFrameworkStores<ApplicationDbEFContext>()
             .AddDefaultTokenProviders();

            //services.AddIdentityServer()
            //.AddDeveloperSigningCredential() // Usar solo en desarrollo. Cambiar para producción.
            //.AddConfigurationStore<ApplicationDbEFContext>()
            //.AddOperationalStore<AdminGym.Persistence.DbContexts.ApplicationDbEFContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            return services;
        }
    }
}
