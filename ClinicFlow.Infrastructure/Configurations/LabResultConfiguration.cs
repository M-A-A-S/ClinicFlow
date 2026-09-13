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
    public class LabResultConfiguration
    : IEntityTypeConfiguration<LabResult>
    {
        public void Configure(EntityTypeBuilder<LabResult> builder)
        {
            builder.ToTable("LabResults");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ResultDate)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.OrderItem)
                .WithOne(x => x.Result)
                .HasForeignKey<LabResult>(x => x.LabOrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasIndex(x => x.LabOrderItemId)
            //    .IsUnique()
            //    .HasDatabaseName("UX_LabResults_OrderItem");

            builder.HasMany(x => x.Values)
                .WithOne(x => x.LabResult)
                .HasForeignKey(x => x.LabResultId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
