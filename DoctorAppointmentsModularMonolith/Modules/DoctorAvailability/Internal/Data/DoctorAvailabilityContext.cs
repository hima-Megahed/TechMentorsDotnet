using System.Reflection;

namespace DoctorAvailability.Internal.Data;
internal class DoctorAvailabilityContext(DbContextOptions<DoctorAvailabilityContext> options)
    : DbContext(options)
{
    internal DbSet<DoctorSlot> DoctorSlots { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("DoctorAvailability");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
