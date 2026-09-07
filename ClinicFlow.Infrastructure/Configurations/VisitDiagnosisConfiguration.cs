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
    public class VisitDiagnosisConfiguration
    : IEntityTypeConfiguration<VisitDiagnosis>
    {
        public void Configure(EntityTypeBuilder<VisitDiagnosis> builder)
        {
            builder.ToTable("VisitDiagnoses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.VisitId)
                .IsRequired();

            builder.Property(x => x.DiagnosisId)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.Visit)
                .WithMany(x => x.VisitDiagnoses)
                .HasForeignKey(x => x.VisitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Diagnosis)
                .WithMany(x => x.VisitDiagnoses)
                .HasForeignKey(x => x.DiagnosisId)
                .OnDelete(DeleteBehavior.Restrict);

            // Same diagnosis cannot be added twice to the same visit
            builder.HasIndex(x => new
            {
                x.VisitId,
                x.DiagnosisId
            })
            .IsUnique()
            .HasDatabaseName("UX_VisitDiagnoses_Visit_Diagnosis")
            .HasFilter("[IsDeleted] = 0");
        }
    }
}
