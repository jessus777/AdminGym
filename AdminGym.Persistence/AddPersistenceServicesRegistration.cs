using AdminGym.Application.Contracts.Infrastructure;
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

            services.AddIdentity<User, Role>(options =>
            {
                // Configuración de políticas de contraseñas
                options.Password.RequireDigit = true; // Requiere al menos un dígito
                options.Password.RequireLowercase = true; // Requiere al menos una letra minúscula
                options.Password.RequireUppercase = true; // Requiere al menos una letra mayúscula
                options.Password.RequireNonAlphanumeric = true; // Requiere al menos un carácter especial
                options.Password.RequiredLength = 12; // Longitud mínima de la contraseña
                options.Password.RequiredUniqueChars = 3; // Número mínimo de caracteres únicos

                // Otras configuraciones
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.User.RequireUniqueEmail = true; // Requiere que el email sea único
            })
             .AddEntityFrameworkStores<ApplicationDbEFContext>()
             .AddDefaultTokenProviders();

            //services.AddIdentityServer()
            //.AddDeveloperSigningCredential() // Usar solo en desarrollo. Cambiar para producción.
            //.AddConfigurationStore<ApplicationDbEFContext>()
            //.AddOperationalStore<AdminGym.Persistence.DbContexts.ApplicationDbEFContext>();
            //services.AddScoped<IOperationContextProvider, OperationContextProvider>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserManagmentUnitOfWork, UserManagmentUnitOfWork>();
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<IPermissionRepositoryAsync, PermissionRepositoryAsync>();
            return services;
        }
    }
}
