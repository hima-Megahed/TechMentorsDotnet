using System.Reflection;
using DoctorAvailability.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAvailability.Data.DbContext;
public class DoctorAvailabilityContext(DbContextOptions<DoctorAvailabilityContext> options)
    : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<DoctorSlot> DoctorSlots { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("DoctorAvailability");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
