namespace QualityPointDevelopmentTestTask.Configuration;

using QualityPointDevelopmentTestTask.Middlewares;

public static class MiddlewaresConfiguration
{
    public static void UseAppMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionsMiddleware>();
    }
}
