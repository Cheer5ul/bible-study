using BibleStudy.Application.Services;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Persistence;
using BibleStudy.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
    
app.MapControllers();

app.Run();
