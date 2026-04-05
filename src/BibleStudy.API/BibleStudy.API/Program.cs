using System.Diagnostics;
using System.Globalization;
using BibleStudy.API.Contracts.Verse;
using BibleStudy.API.Handlers;
using BibleStudy.API.Middlewares;
using BibleStudy.Application.Services;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Persistence;
using BibleStudy.Persistence.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using BibleStudy.API.Validators;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);

// Fluent Validators
builder.Services.AddValidatorsFromAssemblyContaining<ChapterRequestValidator>();
builder.Services.AddScoped<IValidator<ChapterRequest>, ChapterRequestValidator>();

var configuration = builder.Configuration;

builder.Services.AddProblemDetails(configure =>
{
    configure.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
        context.ProblemDetails.Extensions["requestId"] = context.HttpContext.TraceIdentifier;
        Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
        context.ProblemDetails.Extensions["traceId"] = activity?.Id;
    };
});
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BibleStudyDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(BibleStudyDbContext)));
});

builder.Services.AddScoped<IVerseRepository, VerseRepository>();
builder.Services.AddScoped<IVerseService, VerseService>();

builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<IChapterService, ChapterService>();

builder.Services.AddScoped<IFailureHandler, FailureHandler>();

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();
    
app.MapControllers();

app.UseCors("BlazorPolicy");

app.Run();
