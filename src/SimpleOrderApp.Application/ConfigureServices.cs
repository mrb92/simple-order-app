using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using SimpleOrderApp.Application.Common.Behaviours;
using SimpleOrderApp.Common.Services;

using System.Reflection;

namespace SimpleOrderApp.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddInfrastructureServices();

            return services;
        }

        private static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            //todo: request cache behaviour

            services.AddTransient<ITimeService, TimeService>();
        }
    }
}
