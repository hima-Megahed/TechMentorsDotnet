using DoctorAvailability1.Internal.Data;
using DoctorAvailability1.Internal.Services;

namespace DoctorAvailability1.Shared.Registrar;
public static class DoctorAvailabilityModule
{
    public static IServiceCollection AddDoctorAvailabilityModule(this IServiceCollection services,
       IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");


        services.AddDbContext<DoctorAvailabilityContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<DoctorSlotRepo>();
        services.AddScoped<DoctorSlotService>();

        return services;
    }
}
