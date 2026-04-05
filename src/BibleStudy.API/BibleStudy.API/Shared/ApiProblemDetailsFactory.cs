using BibleStudy.Core.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Shared;

public static class ApiProblemDetailsFactory
{
    /// <summary>
    /// Creates a 400 Bad Request ProblemDetails for a FluentValidation exception,
    /// grouping errors by property name
    /// </summary>
    public static ProblemDetails Create(
        ValidationException validationException,
        HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        var problemDetails = new ProblemDetails()
        {
            Type = validationException.GetType().Name,
            Title = "An error occured",
            Detail = validationException.Message,
            Status = StatusCodes.Status400BadRequest
        };
        
        var errors = validationException.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key.ToLowerInvariant(),
                g => g.Select(e => e.ErrorMessage).ToArray()
            );
        
        problemDetails.Extensions.Add("errors", errors);

        return problemDetails;
    }
    
    /// <summary>
    /// Creates a 500 Internal Server Error ProblemDetails for an unhandled exception
    /// </summary>
    public static ProblemDetails Create(
        Exception exception,
        HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var problemDetails = new ProblemDetails()
        {
            Type = exception.GetType().Name,
            Title = "An error occured",
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError
        };
        
        return problemDetails;
    }
    
}