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
    public class PrescriptionItemConfiguration
    : IEntityTypeConfiguration<PrescriptionItem>
    {
        public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
        {
            builder.ToTable("PrescriptionItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PrescriptionId)
                .IsRequired();

            builder.Property(x => x.MedicineId)
                .IsRequired(false);

            builder.Property(x => x.MedicineName)
                .HasMaxLength(300)
                .IsRequired(false);

            builder.Property(x => x.Dosage)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.Frequency)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.Duration)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.Instructions)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.Prescription)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Medicine)
                .WithMany(x => x.PrescriptionItems)
                .HasForeignKey(x => x.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.PrescriptionId)
                .HasDatabaseName("IX_PrescriptionItems_PrescriptionId");

            builder.HasIndex(x => x.MedicineId)
                .HasDatabaseName("IX_PrescriptionItems_MedicineId")
                .HasFilter("[MedicineId] IS NOT NULL");
        }
    }
}
