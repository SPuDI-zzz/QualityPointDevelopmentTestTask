namespace QualityPointDevelopmentTestTask.Configuration
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddAppCors(this IServiceCollection services)
        {
            services.AddCors();
            return services;
        }

        public static void UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .WithMethods("GET")
                .AllowAnyHeader()
            );
        }
    }
}
