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
    public class LabOrderItemConfiguration
    : IEntityTypeConfiguration<LabOrderItem>
    {
        public void Configure(EntityTypeBuilder<LabOrderItem> builder)
        {
            builder.ToTable("LabOrderItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(LabStatus.Pending);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.LabTest)
                .WithMany()
                .HasForeignKey(x => x.LabTestId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasIndex(x => new
            //{
            //    x.LabOrderId,
            //    x.LabTestId
            //})
            //.HasDatabaseName("IX_LabOrderItems_Order_Test");
        }
    }
}
