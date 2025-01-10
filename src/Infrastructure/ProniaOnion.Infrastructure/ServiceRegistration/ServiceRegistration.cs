
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Infrastructure.Implementations.Services;

namespace ProniaOnion.Infrastructure.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler,TokenHandlerService>();
            return services;
        }
    }
}
