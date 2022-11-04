namespace SimpleOrderApp.WebApi
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddCorsAndPolicy(services, configuration);

            return services;
        }

        private static void AddCorsAndPolicy(IServiceCollection services, IConfiguration configuration)
        {
            string[] origins = configuration.GetSection("AllowedOrigins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithExposedHeaders("Content-Disposition")
                    );
            });
        }
    }
}
