using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Infrastructure.Persistence;

namespace SimpleOrderApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddStorage(configuration);

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
