using QualityPointDevelopmentTestTask.Services;

namespace QualityPointDevelopmentTestTask;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddScoped<IAddressService, AddressService>()
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
