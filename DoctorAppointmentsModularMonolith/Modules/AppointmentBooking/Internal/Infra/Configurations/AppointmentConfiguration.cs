using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentBooking.Internal.Data.Configurations;
internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.Property(p => p.PatientName).HasMaxLength(100);


    }
}