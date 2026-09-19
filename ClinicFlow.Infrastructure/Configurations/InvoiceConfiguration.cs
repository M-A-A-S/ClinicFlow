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
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.InvoiceDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Subtotal)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.DiscountAmount)
                .HasPrecision(18, 2)
                .HasDefaultValue(0.00m);

            builder.Property(x => x.TaxAmount)
                .HasPrecision(18, 2)
                .HasDefaultValue(0.00m);

            builder.Property(x => x.GrandTotal)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.PaidAmount)
                .HasPrecision(18, 2)
                .HasDefaultValue(0.00m);

            builder.Property(x => x.RemainingAmount)
            .HasPrecision(18, 2)
            .IsRequired();

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Invoice)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Payments)
                .WithOne(x => x.Invoice)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.InvoiceNumber)
                .IsUnique()
                .HasDatabaseName("UX_Invoices_InvoiceNumber")
                .HasFilter("[IsDeleted] = 0");

        }
    }
}
