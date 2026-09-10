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
    public class PrescriptionConfiguration
    : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PrescriptionNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.VisitId)
                .IsRequired();

            builder.Property(x => x.PrescriptionDate)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasMaxLength(2000)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasIndex(x => x.PrescriptionNumber)
                .IsUnique()
                .HasDatabaseName("UX_Prescriptions_PrescriptionNumber")
                .HasFilter("[IsDeleted] = 0");

            builder.HasIndex(x => x.VisitId)
                .HasDatabaseName("IX_Prescriptions_VisitId")
                .HasFilter("[IsDeleted] = 0");

            builder.HasOne(x => x.Visit)
                .WithOne(x => x.Prescription)
                .HasForeignKey<Prescription>(x => x.VisitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
