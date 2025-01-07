using System.Reflection;

namespace AppointmentBooking.Internal.Data;
internal class AppointmentBookingContext(DbContextOptions<AppointmentBookingContext> options)
    : DbContext(options)
{
    internal DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("AppointmentBooking");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
