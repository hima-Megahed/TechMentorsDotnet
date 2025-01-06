using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorAvailability.Internal.Data.Configurations;
internal class DoctorSlotConfiguration : IEntityTypeConfiguration<DoctorSlot>
{
    public void Configure(EntityTypeBuilder<DoctorSlot> builder)
    {
        //builder.HasKey(p => p.Id);
        //builder.Property(p => p.Date).IsRequired();
        //builder.Property(p => p.DoctorId).IsRequired();

        //builder.Property(p => p.DoctorName).IsRequired().HasMaxLength(100);

        //builder.Property(p => p.IsReserved);
        //builder.Property(p => p.Cost).HasColumnType("decimal(18,2)");
    }
}