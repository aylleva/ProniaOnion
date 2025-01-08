using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace ProniaOnion.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
