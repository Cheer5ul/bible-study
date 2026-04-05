using System.Diagnostics;
using BibleStudy.API.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

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
        
        var problemDetails = ApiProblemDetailsFactory.Create(validationException, httpContext);
        
        var problemDetailsContext = new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            Exception = validationException,
            ProblemDetails = problemDetails
        };
        
        return await problemDetailsService.TryWriteAsync(problemDetailsContext);
    }
}