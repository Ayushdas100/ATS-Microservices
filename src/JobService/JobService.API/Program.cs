using JobService.Application.Interfaces;
using JobService.Application.Services;
using JobService.Infrastructure.Persistence;
using JobService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
var builder = WebApplication.CreateBuilder(args);

// 1. Add Database Context
builder.Services.AddDbContext<JobDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register Dependencies (Dependency Injection)
builder.Services.AddScoped<IJobPostRepository, JobPostRepository>();
builder.Services.AddScoped<IJobPostService, JobPostService>();
builder.Services.AddAutoMapper(cfg =>
{
    // The new standard way to register profiles in AutoMapper 15+
    cfg.AddProfile<JobService.Application.Profiles.MappingProfile>();
});
builder.Services.AddValidatorsFromAssemblyContaining<JobService.Application.Validators.CreateJobPostDtoValidator>();
// 1. Register the Exception Handler
builder.Services.AddExceptionHandler<JobService.API.Middlewares.GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();