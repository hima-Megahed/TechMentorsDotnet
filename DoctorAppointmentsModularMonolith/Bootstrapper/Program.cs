using AppointmentBooking.Shared.Registrar;
using AppointmentConfirmation.Shared.Registrar;
using Carter;
using DoctorAppointmentManagement.Shared.Registrar;
using DoctorAvailability.Shared.Registrar;
using Scalar.AspNetCore;
using Shared.Exceptions.Handler;
using Shared.Extensions;
using Shared.Messaging.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var doctorAvailabilityAssembly = typeof(DoctorAvailabilityModule).Assembly;
var appointmentBookingAssembly = typeof(AppointmentBookingModule).Assembly;
var appointmentConfirmationAssembly = typeof(AppointmentConfirmationModule).Assembly;
var doctorAppointmentManagementAssembly = typeof(DoctorAppointmentManagementModule).Assembly;



builder.Services
    .AddCarterWithAssemblies(doctorAvailabilityAssembly, appointmentBookingAssembly, appointmentConfirmationAssembly, doctorAppointmentManagementAssembly);

builder.Services
    .AddMediatRWithAssemblies(appointmentBookingAssembly);

builder.Services
    .AddMassTransitWithAssemblies(appointmentConfirmationAssembly);


builder.Services
    .AddDoctorAvailabilityModule(builder.Configuration)
    .AddAppointmentBookingModule(builder.Configuration)
    .AddDoctorAppointmentManagementModule()
    .AddAppointmentConfirmationModule();

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.MapCarter();
app.UseExceptionHandler(options => { });

app.Run();

