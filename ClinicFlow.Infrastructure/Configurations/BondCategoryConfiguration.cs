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
    public class BondCategoryConfiguration : IEntityTypeConfiguration<BondCategory>
    {
        public void Configure(EntityTypeBuilder<BondCategory> builder)
        {
            builder.ToTable("BondCategories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasData(LoadBondCategories());
        }

        private static List<BondCategory> LoadBondCategories()
        {
            return new()
        {
            new BondCategory { Id = 1, NameEn = "General Receipt", NameAr = "قبض عام", Type = BondType.Receipt, IsActive = true },
            new BondCategory { Id = 2, NameEn = "General Expense", NameAr = "مصروفات عامة", Type = BondType.Payment, IsActive = true },
            new BondCategory { Id = 3, NameEn = "Supplier Payment", NameAr = "دفعة للمورد", Type = BondType.Payment, IsActive = true }
        };
        }

    }
}
