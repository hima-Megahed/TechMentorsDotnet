﻿// <auto-generated />
using System;
using AppointmentBooking.Internal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentBooking.Migrations
{
    [DbContext(typeof(AppointmentBookingContext))]
    partial class AppointmentBookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AppointmentBooking")
                .HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("AppointmentBooking.Internal.Domain.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ReservedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SlotId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Appointments", "AppointmentBooking");
                });
#pragma warning restore 612, 618
        }
    }
}
