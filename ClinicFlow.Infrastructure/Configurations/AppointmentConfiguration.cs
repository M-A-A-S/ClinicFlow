using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Configurations
{
    public class AppointmentConfiguration
    : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AppointmentNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.PatientId)
                .IsRequired();

            builder.Property(x => x.ClinicId)
                .IsRequired();

            builder.Property(x => x.DoctorId)
                .IsRequired();

            builder.Property(x => x.StartAt)
                .IsRequired();

            builder.Property(x => x.EndAt)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(AppointmentStatus.Scheduled);

            builder.Property(x => x.Reason)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Notes)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            // Appointment Number
            builder.HasIndex(x => x.AppointmentNumber)
                .IsUnique()
                .HasDatabaseName("UX_Appointments_AppointmentNumber")
                .HasFilter("[IsDeleted] = 0");

            // Patient
            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clinic
            builder.HasOne(x => x.Clinic)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            // Doctor
            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Appointment -> Zero or One Queue
            builder.HasOne(x => x.WaitingQueue)
                .WithOne(x => x.Appointment)
                .HasForeignKey<WaitingQueue>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Appointment -> Zero or One Visit
            builder.HasOne(x => x.Visit)
                .WithOne(x => x.Appointment)
                .HasForeignKey<Visit>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
