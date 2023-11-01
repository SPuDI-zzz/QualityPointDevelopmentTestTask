using QualityPointDevelopmentTestTask.Exceptions;

namespace QualityPointDevelopmentTestTask.Middlewares;

public class ExceptionsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionsMiddleware> _logger;

    public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
    {
        this._next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string? errorMessage = null;
        try
        {
            await _next.Invoke(context);
        }
        catch(ProcessException ex)
        {
            errorMessage = ex.Message;
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            _logger.LogError(ex.ToString());
        }
        finally
        {
            if (errorMessage is not null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(errorMessage);
            }
        }
    }
}
