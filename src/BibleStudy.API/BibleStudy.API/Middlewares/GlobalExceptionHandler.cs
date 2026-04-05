using BibleStudy.API.Shared;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Middlewares;

/// <summary>
/// Convention middleware for global exception handling
/// </summary>
internal sealed class GlobalExceptionHandler(
    IProblemDetailsService problemDetailsService,
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exceptin occured");

        var problemDetails = ApiProblemDetailsFactory.Create(exception, httpContext);
        
        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = problemDetails
        });
    }
}