using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Refit;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Domain.Interfaces;
using SimpleOrderApp.Infrastructure.ExternalApiIntegration;
using SimpleOrderApp.Infrastructure.Persistence;

namespace SimpleOrderApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddStorage(configuration);
            services.AddRefit();

            return services;
        }

        private static IServiceCollection AddRefit(this IServiceCollection services)
        {
            services.AddRefitClient(typeof(IExternalCurrenyApiIntegration));
            services.AddScoped<IExternalApiIntegrationService, ExternalApiIntegrationService>();

            return services;
        }

        private static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .EnableDetailedErrors()
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOpt =>
                    {
                        sqlOpt.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: new[] { 18456 }
                        );
                    }
                )
            );

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
