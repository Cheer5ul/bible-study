using BibleStudy.API.Shared;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Handlers;

public class FailureHandler : IFailureHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public FailureHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }
    
    public async Task<ActionResult> HandleFailure(Result result, HttpContext httpContext)
    {
        if (!result.IsFailure)
        {
            throw new InvalidOperationException("Cannot handle successful result.");
        }
        
        var problemDetails = new ProblemDetails()
        {
            // need to make methods to detect each field
            Status = StatusCodes.Status400BadRequest,
            Title = "One or more validation errors occurred",
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Extensions = GetErrorsExtension(result.Errors)!
        };
        
        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails
        });

        return new EmptyResult();
    }

    protected static Dictionary<string, object>? GetErrorsExtension(IReadOnlyList<Error> errors)
    {
        if (!errors.Any())
        {
            return null;
        }

        var extensions = new Dictionary<string, object>();

        extensions["errors"] = errors.Select(e => new 
        {
            code  = e.Code,
            description = e.Description,
        }).ToList();
        
        return extensions.Any() ? extensions : null;
    }
}