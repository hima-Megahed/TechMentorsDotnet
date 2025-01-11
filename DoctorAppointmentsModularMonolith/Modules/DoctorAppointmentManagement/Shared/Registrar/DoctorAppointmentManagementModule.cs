using DoctorAppointmentManagement.Internal.Core.Ports.Data.Repos;
using DoctorAppointmentManagement.Internal.Core.Ports.Repos;
using DoctorAppointmentManagement.Internal.Core.Services;
using DoctorAppointmentManagement.Internal.Shell.Data;
using DoctorAppointmentManagement.Internal.Shell.Data.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAppointmentManagement.Shared.Registrar;
public static class DoctorAppointmentManagementModule
{
    public static IServiceCollection AddDoctorAppointmentManagementModule(this IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();
        services.AddScoped<IUpcomingAppointmentsRepo, UpcomingAppointmentsRepo>();
        services.AddScoped<IUpcomingAppointmentsService, UpcomingAppointmentsService>();


        return services;
    }
}
