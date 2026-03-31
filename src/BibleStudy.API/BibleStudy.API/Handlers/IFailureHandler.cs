using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Handlers;

public interface IFailureHandler
{
    ActionResult HandleFailure(Result result, HttpContext httpContext);
    Dictionary<string, object>? GetErrorsExtension(IReadOnlyList<Error> errors);
}