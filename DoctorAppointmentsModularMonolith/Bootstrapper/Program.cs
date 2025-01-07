using Carter;
using DoctorAvailability.Shared.Registrar;
using Scalar.AspNetCore;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var doctorAvailabilityAssembly = typeof(DoctorAvailabilityModule).Assembly;

builder.Services
    .AddCarterWithAssemblies(doctorAvailabilityAssembly);

builder.Services
    .AddDoctorAvailabilityModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.MapCarter();

app.Run();

