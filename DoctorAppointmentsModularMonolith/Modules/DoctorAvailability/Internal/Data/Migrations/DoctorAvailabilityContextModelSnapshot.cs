﻿// <auto-generated />
using System;
using DoctorAvailability.Internal.Data;
using DoctorAvailability1.Internal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorAvailability.Internal.Data.Migrations
{
    [DbContext(typeof(DoctorAvailabilityContext))]
    partial class DoctorAvailabilityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("DoctorAvailability")
                .HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("DoctorAvailability.Internal.Models.DoctorSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DoctorSlots", "DoctorAvailability");
                });
#pragma warning restore 612, 618
        }
    }
}
