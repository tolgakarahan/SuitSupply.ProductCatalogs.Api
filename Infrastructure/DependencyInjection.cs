using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<INotificationService, NotificationService>();

            return services;

        }
    }
}
