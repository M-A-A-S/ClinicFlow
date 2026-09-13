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
    public class LabResultValueConfiguration
    : IEntityTypeConfiguration<LabResultValue>
    {
        public void Configure(EntityTypeBuilder<LabResultValue> builder)
        {
            builder.ToTable("LabResultValues");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .IsRequired(false)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.Property(x => x.NumericValue)
                .IsRequired(false)
                .HasPrecision(18, 4);

            builder.Property(x => x.Unit)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(x => x.NormalRange)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(x => x.Flag)
                .IsRequired()
                .HasDefaultValue(LabResultFlag.None);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();


            builder.HasOne(x => x.Parameter)
                .WithMany()
                .HasForeignKey(x => x.ParameterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.LabResultId,
                x.ParameterId
            })
            .IsUnique()
            .HasDatabaseName("UX_LabResultValues_Result_Parameter");
        }
    }
}
