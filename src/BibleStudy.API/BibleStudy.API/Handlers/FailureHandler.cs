using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Handlers;

public class FailureHandler : IFailureHandler
{
    public ActionResult HandleFailure(Result result, HttpContext httpContext)
    {
        if (!result.IsFailure)
        {
            throw new InvalidOperationException("Cannot handle successful result.");
        }
        
        var problem = new ProblemDetails()
        {
            // need to make methods to detect each field
            Status = StatusCodes.Status400BadRequest,
            Title = "One or more validation errors occurred",
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Extensions = GetErrorsExtension(result.Errors)!
        };

        return new ObjectResult(problem) {StatusCode = problem.Status} ;
    }

    public Dictionary<string, object>? GetErrorsExtension(IReadOnlyList<Error> errors)
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