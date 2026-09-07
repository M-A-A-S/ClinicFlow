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
    public class VisitConfiguration
    : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable("Visits");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.VisitNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.PatientId)
                .IsRequired();

            builder.Property(x => x.DoctorId)
                .IsRequired();

            builder.Property(x => x.ClinicId)
                .IsRequired();

            builder.Property(x => x.WaitingQueueId)
                .IsRequired(false);

            builder.Property(x => x.AppointmentId)
                .IsRequired(false);

            builder.Property(x => x.VisitDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(VisitStatus.Open);

            builder.Property(x => x.Complaint)
                .HasMaxLength(2000)
                .IsRequired(false);

            builder.Property(x => x.ClinicalNotes)
                .HasMaxLength(5000)
                .IsRequired(false);

            builder.Property(x => x.CompletedAt)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            // Visit Number
            builder.HasIndex(x => x.VisitNumber)
                .IsUnique()
                .HasDatabaseName("UX_Visits_VisitNumber")
                .HasFilter("[IsDeleted] = 0");

            // Patient
            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Doctor
            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clinic
            builder.HasOne(x => x.Clinic)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            // Queue
            builder.HasOne(x => x.WaitingQueue)
                .WithOne()
                .HasForeignKey<Visit>(x => x.WaitingQueueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment
            builder.HasOne(x => x.Appointment)
                .WithOne(x => x.Visit)
                .HasForeignKey<Visit>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Queue -> maximum one Visit
            builder.HasIndex(x => x.WaitingQueueId)
                .IsUnique()
                .HasDatabaseName("UX_Visits_Queue")
                .HasFilter("[WaitingQueueId] IS NOT NULL AND [IsDeleted] = 0");

            // One Appointment -> maximum one Visit
            builder.HasIndex(x => x.AppointmentId)
                .IsUnique()
                .HasDatabaseName("UX_Visits_Appointment")
                .HasFilter("[AppointmentId] IS NOT NULL AND [IsDeleted] = 0");
        }
    }
}
