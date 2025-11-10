using FluentValidation;
using MedicalReports.Application.Interfaces;
using MedicalReports.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalReportsConnectionString"));
});

builder.Services.AddScoped<IAppDbContext, AppDbContext>();

builder.Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IAppDbContext).Assembly))
    .AddAutoMapper(typeof(IAppDbContext).Assembly)
    .AddValidatorsFromAssembly(typeof(IAppDbContext).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
