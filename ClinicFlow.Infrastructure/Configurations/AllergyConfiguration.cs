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
    public class AllergyConfiguration
        : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.ToTable("Allergies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.DescriptionEn)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.DescriptionAr)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

            builder.HasIndex(x => x.NameEn)
                .IsUnique()
                .HasDatabaseName("UX_Allergies_NameEn")
                .HasFilter("[IsDeleted] = 0");

            builder.HasIndex(x => x.NameAr)
                .IsUnique()
                .HasDatabaseName("UX_Allergies_NameAr")
                .HasFilter("[IsDeleted] = 0");

            builder.HasData(LoadAllergies());

        }

        private static List<Allergy> LoadAllergies()
        {
            return new()
    {
        new Allergy
        {
            Id = 1,
            NameEn = "Penicillin",
            NameAr = "البنسلين",
            DescriptionEn = "Allergy to penicillin antibiotics",
            DescriptionAr = "حساسية تجاه المضادات الحيوية من نوع البنسلين",
            IsActive = true
        },
        new Allergy
        {
            Id = 2,
            NameEn = "Aspirin",
            NameAr = "الأسبرين",
            DescriptionEn = "Allergy to aspirin",
            DescriptionAr = "حساسية تجاه الأسبرين",
            IsActive = true
        },
        new Allergy
        {
            Id = 3,
            NameEn = "Ibuprofen",
            NameAr = "الإيبوبروفين",
            DescriptionEn = "Allergy to ibuprofen",
            DescriptionAr = "حساسية تجاه الإيبوبروفين",
            IsActive = true
        },
        new Allergy
        {
            Id = 4,
            NameEn = "Latex",
            NameAr = "اللاتكس",
            DescriptionEn = "Allergy to latex",
            DescriptionAr = "حساسية تجاه مادة اللاتكس",
            IsActive = true
        },
        new Allergy
        {
            Id = 5,
            NameEn = "Peanuts",
            NameAr = "الفول السوداني",
            DescriptionEn = "Allergy to peanuts",
            DescriptionAr = "حساسية تجاه الفول السوداني",
            IsActive = true
        },
        new Allergy
        {
            Id = 6,
            NameEn = "Milk",
            NameAr = "الحليب",
            DescriptionEn = "Allergy to milk or dairy products",
            DescriptionAr = "حساسية تجاه الحليب أو منتجات الألبان",
            IsActive = true
        },
        new Allergy
        {
            Id = 7,
            NameEn = "Eggs",
            NameAr = "البيض",
            DescriptionEn = "Allergy to eggs",
            DescriptionAr = "حساسية تجاه البيض",
            IsActive = true
        },
        new Allergy
        {
            Id = 8,
            NameEn = "Shellfish",
            NameAr = "المحار",
            DescriptionEn = "Allergy to shellfish",
            DescriptionAr = "حساسية تجاه المحار",
            IsActive = true
        }
    };
        }

    }

}

