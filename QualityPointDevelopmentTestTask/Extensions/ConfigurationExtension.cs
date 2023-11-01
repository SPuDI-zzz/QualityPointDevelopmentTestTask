using Microsoft.Extensions.Options;

namespace QualityPointDevelopmentTestTask.Extensions;

public static class ConfigurationExtension
{
    public static T GetConfiguration<T>(this IServiceProvider serviceProvider)
        where T : class
    {
        var o = serviceProvider.GetService<IOptions<T>>();

        return o is null ? 
            throw new ArgumentNullException(nameof(T)) : 
            o.Value;
    }
}
