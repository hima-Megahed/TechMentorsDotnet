


using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Data.Interceptors;

namespace AppointmentBooking.Shared.Registrar;
public static class AppointmentBookingModule
{
    public static IServiceCollection AddAppointmentBookingModule(this IServiceCollection services,
       IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<AppointmentBookingContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlite(connectionString);
        });



        return services;
    }
}
