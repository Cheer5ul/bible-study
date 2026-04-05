using BibleStudy.Core.Results.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Shared;

public abstract class ApiProblemDetailsFactory
{
    public static ProblemDetails Create(
        ValidationException validationException,
        HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        var problemDetails = new ProblemDetails()
        {
            Detail = "One or more validation errors occurred",
            Status = StatusCodes.Status400BadRequest
        };
        
        var errors = validationException.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key.ToLowerInvariant(),
                g => g.Select(e => e.ErrorMessage).ToArray()
            );

        return problemDetails;
    }

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
        };
        
        return problemDetails;
    }
}