using BibleStudy.API.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace BibleStudy.API.Middlewares;

internal sealed class ValidationExceptionHandler(
    IProblemDetailsService problemDetailsService,
    ILogger<ValidationExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception,
        CancellationToken cancellation)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        var problemDetails = ApiProblemDetailsFactory.Create(validationException, httpContext);
        
        var problemDetailsContext = new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            Exception = validationException,
            ProblemDetails = problemDetails
        };
        
        problemDetailsContext.ProblemDetails.Extensions.Add("errors", problemDetails);

        return await problemDetailsService.TryWriteAsync(problemDetailsContext);
    }
}