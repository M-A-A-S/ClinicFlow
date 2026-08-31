using ClinicFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Configurations
{
    public class PatientChronicConditionConfiguration
        : IEntityTypeConfiguration<PatientChronicCondition>
    {
        public void Configure(EntityTypeBuilder<PatientChronicCondition> builder)
        {
            builder.ToTable("PatientChronicConditions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Notes)
                .HasMaxLength(1000);

            builder.Property(x => x.DiagnosedAt);

            builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.PatientChronicConditions)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChronicCondition)
                .WithMany(x => x.PatientChronicConditions)
                .HasForeignKey(x => x.ChronicConditionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.PatientId,
                x.ChronicConditionId
            })
            .IsUnique()
            .HasDatabaseName("UX_PatientChronicConditions_Patient_Condition")
        .HasFilter("[IsDeleted] = 0");

            builder.HasData(LoadPatientChronicConditions());

        }

        private static List<PatientChronicCondition> LoadPatientChronicConditions()
        {
            return new()
        {
            new PatientChronicCondition
            {
                Id = 1,
                PatientId = 1,
                ChronicConditionId = 1,
                Notes = "Type 2 diabetes",
                DiagnosedAt = new DateTime(2018, 4, 12)
            },

            new PatientChronicCondition
            {
                Id = 2,
                PatientId = 1,
                ChronicConditionId = 2,
                Notes = "Currently under treatment",
                DiagnosedAt = new DateTime(2020, 9, 20)
            },

            new PatientChronicCondition
            {
                Id = 3,
                PatientId = 2,
                ChronicConditionId = 3,
                Notes = "Intermittent asthma",
                DiagnosedAt = new DateTime(2016, 2, 15)
            },

            new PatientChronicCondition
            {
                Id = 4,
                PatientId = 3,
                ChronicConditionId = 2,
                Notes = "Regular blood pressure monitoring",
                DiagnosedAt = new DateTime(2019, 7, 10)
            },

            new PatientChronicCondition
            {
                Id = 5,
                PatientId = 5,
                ChronicConditionId = 4,
                Notes = "Requires regular kidney function monitoring",
                DiagnosedAt = new DateTime(2022, 11, 5)
            }
        };

        }
    }
}
