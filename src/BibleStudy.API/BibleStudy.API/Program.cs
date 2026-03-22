using System.Globalization;
using BibleStudy.Application.Services;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Persistence;
using BibleStudy.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);

var configuration = builder.Configuration;

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

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5051/")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Fluent Validators
builder.Services.AddFluentValidationAutoValidation();
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
    
app.MapControllers();

app.Run();
