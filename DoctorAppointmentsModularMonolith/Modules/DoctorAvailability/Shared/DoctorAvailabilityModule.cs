using DoctorAvailability.Internal.Services;

namespace DoctorAvailability.Shared;
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
        services.AddScoped<DoctorSlotServcie>();

        return services;
    }
}
