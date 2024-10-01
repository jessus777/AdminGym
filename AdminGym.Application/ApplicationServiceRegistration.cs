using AdminGym.Application.Behaviors;
using AdminGym.Application.Request;
using AdminGym.Domain.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AdminGym.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceLayer(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


        //services.AddValidatorsFromAssemblyContaining<AppDomain>();

        //services.AddMediatR(config =>
        //{
        //    config.RegisterServicesFromAssemblyContaining<AppDomain>();
        //    config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        //    config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //});

        return services;
    }
}
