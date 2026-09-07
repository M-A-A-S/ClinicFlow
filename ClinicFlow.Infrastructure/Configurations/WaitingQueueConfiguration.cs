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
    public class WaitingQueueConfiguration
    : IEntityTypeConfiguration<WaitingQueue>
    {
        public void Configure(EntityTypeBuilder<WaitingQueue> builder)
        {
            builder.ToTable("WaitingQueues");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AppointmentId)
                .IsRequired(false);

            builder.Property(x => x.PatientId)
                .IsRequired();

            builder.Property(x => x.DoctorId)
                .IsRequired();

            builder.Property(x => x.ClinicId)
                .IsRequired();

            builder.Property(x => x.WaitingQueueDate)
                .IsRequired();

            builder.Property(x => x.WaitingQueueNumber)
                .IsRequired();

            builder.Property(x => x.JoinedAt)
                .IsRequired();

            builder.Property(x => x.Priority)
                .IsRequired()
                .HasDefaultValue(QueuePriority.Normal);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(QueueStatus.Waiting);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            // Patient
            builder.HasOne(x => x.Patient)
                .WithMany(x => x.WaitingQueues)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment
            builder.HasOne(x => x.Appointment)
                .WithOne(x => x.WaitingQueue)
                .HasForeignKey<WaitingQueue>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Doctor
            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.WaitingQueues)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clinic
            builder.HasOne(x => x.Clinic)
                .WithMany()
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            // Queue number resets every day per clinic
            builder.HasIndex(x => new
            {
                x.ClinicId,
                x.WaitingQueueDate,
                x.WaitingQueueNumber
            })
            .IsUnique()
            .HasDatabaseName("UX_Queues_Clinic_Date_Number")
            .HasFilter("[IsDeleted] = 0");

            // An appointment can enter the queue only once
            builder.HasIndex(x => x.AppointmentId)
                .IsUnique()
                .HasDatabaseName("UX_Queues_Appointment")
                .HasFilter("[AppointmentId] IS NOT NULL AND [IsDeleted] = 0");
        }
    }
}
