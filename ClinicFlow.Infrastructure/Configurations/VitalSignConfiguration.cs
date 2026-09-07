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
    public class VitalSignConfiguration
    : IEntityTypeConfiguration<VitalSign>
    {
        public void Configure(EntityTypeBuilder<VitalSign> builder)
        {
            builder.ToTable("VitalSigns");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.VisitId)
                .IsRequired();

            builder.Property(x => x.Temperature)
                .HasPrecision(5, 2)
                .IsRequired(false);

            builder.Property(x => x.Pulse)
                .IsRequired(false);

            builder.Property(x => x.SystolicBloodPressure)
                .IsRequired(false);

            builder.Property(x => x.DiastolicBloodPressure)
                .IsRequired(false);

            builder.Property(x => x.RespiratoryRate)
                .IsRequired(false);

            builder.Property(x => x.OxygenSaturation)
                .HasPrecision(5, 2)
                .IsRequired(false);

            builder.Property(x => x.Weight)
                .HasPrecision(6, 2)
                .IsRequired(false);

            builder.Property(x => x.Height)
                .HasPrecision(6, 2)
                .IsRequired(false);


            builder.Property(x => x.RecordedAt)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.Visit)
                .WithMany(x => x.VitalSigns)
                .HasForeignKey(x => x.VisitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new
            {
                x.VisitId,
                x.RecordedAt
            })
            .HasDatabaseName("IX_VitalSigns_Visit_RecordedAt");
        }
    }
}
