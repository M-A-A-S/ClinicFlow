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
    public class InvoicePaymentConfiguration : IEntityTypeConfiguration<InvoicePayment>
    {
        public void Configure(EntityTypeBuilder<InvoicePayment> builder)
        {
            builder.ToTable("InvoicePayments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ReceiptNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.PaymentDate)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);

            builder.HasOne(x => x.PaymentMethod)
                .WithMany(x => x.InvoicePayments)
                .HasForeignKey(x => x.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(x => x.ReceiptNumber)
                .IsUnique()
                .HasDatabaseName("UX_InvoicePayments_ReceiptNumber")
                .HasFilter("[IsDeleted] = 0");
        }
    }
}
