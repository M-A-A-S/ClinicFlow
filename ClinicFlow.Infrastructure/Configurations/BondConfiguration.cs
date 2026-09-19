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
    public class BondConfiguration : IEntityTypeConfiguration<Bond>
    {
        public void Configure(EntityTypeBuilder<Bond> builder)
        {
            builder.ToTable("Bonds");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BondNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.IssueDate)
                .IsRequired();

            builder.Property(x => x.Party)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.ReferenceNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Notes)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Bonds)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PaymentMethod)
                .WithMany(x => x.Bonds)
                .HasForeignKey(x => x.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.BondNumber)
                .IsUnique()
                .HasDatabaseName("UX_Bonds_BondNumber")
                .HasFilter("[IsDeleted] = 0");

        }
    }
}
