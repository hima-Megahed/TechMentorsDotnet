using DoctorAvailability.Internal;
using DoctorAvailability.Internal.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Data.Interceptors;

namespace DoctorAvailability.Shared.Registrar;
public static class DoctorAvailabilityModule
{
    public static IServiceCollection AddDoctorAvailabilityModule(this IServiceCollection services,
       IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<DoctorAvailabilityContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlite(connectionString);
        });
        services.AddScoped<IDoctorSlotRepo, DoctorSlotRepo>();
        services.AddScoped<DoctorSlotService>();
        services.AddScoped<ISlotFsadService, SlotFsadService>();


        return services;
    }
}
