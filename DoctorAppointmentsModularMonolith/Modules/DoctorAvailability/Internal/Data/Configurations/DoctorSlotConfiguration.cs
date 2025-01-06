﻿using DoctorAvailability1.Internal.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorAvailability1.Internal.Data.Configurations;
internal class DoctorSlotConfiguration : IEntityTypeConfiguration<DoctorSlot>
{
    public void Configure(EntityTypeBuilder<DoctorSlot> builder)
    {
        builder.Property(p => p.Cost).HasColumnType("decimal(18,2)");
    }
}