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
    public class LabCategoryConfiguration
    : IEntityTypeConfiguration<LabCategory>
    {
        public void Configure(EntityTypeBuilder<LabCategory> builder)
        {
            builder.ToTable("LabCategories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.NameAr)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            //builder.HasIndex(x => x.NameEn)
            //    .IsUnique()
            //    .HasDatabaseName("UX_LabCategories_NameEn")
            //    .HasFilter("[IsDeleted] = 0");

            //builder.HasIndex(x => x.NameAr)
            //    .IsUnique()
            //    .HasDatabaseName("UX_LabCategories_NameAr")
            //    .HasFilter("[IsDeleted] = 0");

            builder.HasMany(x => x.Tests)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(LoadCategories());
        }

        private static List<LabCategory> LoadCategories()
        {
            return new()
        {
            new LabCategory
            {
                Id = 1,
                NameEn = "Hematology",
                NameAr = "أمراض الدم",
                IsActive = true
            },
            new LabCategory
            {
                Id = 2,
                NameEn = "Biochemistry",
                NameAr = "الكيمياء الحيوية",
                IsActive = true
            },
            new LabCategory
            {
                Id = 3,
                NameEn = "Immunology",
                NameAr = "المناعة",
                IsActive = true
            },
            new LabCategory
            {
                Id = 4,
                NameEn = "Microbiology",
                NameAr = "الأحياء الدقيقة",
                IsActive = true
            },
            new LabCategory
            {
                Id = 5,
                NameEn = "Hormones",
                NameAr = "الهرمونات",
                IsActive = true
            },
            new LabCategory
            {
                Id = 6,
                NameEn = "Urinalysis",
                NameAr = "تحليل البول",
                IsActive = true
            },
            new LabCategory
            {
                Id = 7,
                NameEn = "Serology",
                NameAr = "الأمصال",
                IsActive = true
            },

            new LabCategory
            {
                Id = 8,
                NameEn = "Parasitology",
                NameAr = "الطفيليات",
                IsActive = true
            }
        };
        }
    }
}
