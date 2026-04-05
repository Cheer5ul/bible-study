using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Handlers;

public interface IFailureHandler
{
    /// <summary>
    /// Handles Result object if not successful 
    /// </summary>
    /// <param name="result">Result object to handle</param>
    /// <param name="httpContext">HttpContext of the request</param>
    /// <returns>ActionResult containing ProblemDetailsContext with error information</returns>
    Task<ActionResult> HandleFailure(Result result, HttpContext httpContext);
}