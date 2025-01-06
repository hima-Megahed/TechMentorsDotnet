using DoctorAvailability.Internal.Services;

namespace DoctorAvailability.Shared.Registrar;
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
        services.AddScoped<IAvailableSlotsService, AvailableSlotsService>();
        services.AddScoped<ISlotInfoService, SlotInfoService>();


        return services;
    }
}
