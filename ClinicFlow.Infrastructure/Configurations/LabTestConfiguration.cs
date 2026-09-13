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
    public class LabTestConfiguration
    : IEntityTypeConfiguration<LabTest>
    {
        public void Configure(EntityTypeBuilder<LabTest> builder)
        {
            builder.ToTable("LabTests");

            builder.HasKey(x => x.Id);

            //builder.Property(x => x.Code)
            //    .IsRequired()
            //    .HasMaxLength(50);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.NameAr)
                .IsRequired(false)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            //builder.HasIndex(x => x.Code)
            //    .IsUnique()
            //    .HasDatabaseName("UX_LabTests_Code")
            //    .HasFilter("[IsDeleted] = 0");

            //builder.HasIndex(x => x.NameEn)
            //    .IsUnique()
            //    .HasDatabaseName("UX_LabTests_NameEn")
            //    .HasFilter("[IsDeleted] = 0");

            //builder.HasIndex(x => x.NameAr)
            //    .IsUnique()
            //    .HasDatabaseName("UX_LabTests_NameAr")
            //    .HasFilter("[IsDeleted] = 0 AND [NameAr] IS NOT NULL");


            builder.HasMany(x => x.Parameters)
                .WithOne(x => x.LabTest)
                .HasForeignKey(x => x.LabTestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(LoadTests());
        }

        private static List<LabTest> LoadTests()
        {
            return new()
    {
        // =========================================================
        // HEMATOLOGY
        // =========================================================

        new LabTest
        {
            Id = 1,
            //Code = "CBC",
            CategoryId = 1,
            NameEn = "Complete Blood Count",
            NameAr = "تعداد الدم الكامل",
            Price = 15.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 2,
            //Code = "ESR",
            CategoryId = 1,
            NameEn = "Erythrocyte Sedimentation Rate",
            NameAr = "سرعة ترسيب كريات الدم الحمراء",
            Price = 10.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 3,
            //Code = "HB",
            CategoryId = 1,
            NameEn = "Hemoglobin",
            NameAr = "الهيموغلوبين",
            Price = 8.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 4,
            //Code = "BLOOD-GROUP",
            CategoryId = 1,
            NameEn = "Blood Group and Rh",
            NameAr = "فصيلة الدم وعامل ريسوس",
            Price = 10.00m,
            IsActive = true
        },

        // =========================================================
        // BIOCHEMISTRY
        // =========================================================

        new LabTest
        {
            Id = 5,
            //Code = "LFT",
            CategoryId = 2,
            NameEn = "Liver Function Test",
            NameAr = "وظائف الكبد",
            Price = 30.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 6,
            //Code = "KFT",
            CategoryId = 2,
            NameEn = "Kidney Function Test",
            NameAr = "وظائف الكلى",
            Price = 30.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 7,
            //Code = "FBS",
            CategoryId = 2,
            NameEn = "Fasting Blood Glucose",
            NameAr = "سكر الدم الصائم",
            Price = 10.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 8,
            //Code = "RBS",
            CategoryId = 2,
            NameEn = "Random Blood Glucose",
            NameAr = "سكر الدم العشوائي",
            Price = 10.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 9,
            //Code = "HBA1C",
            CategoryId = 2,
            NameEn = "HbA1c",
            NameAr = "السكر التراكمي",
            Price = 25.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 10,
            //Code = "LIPID",
            CategoryId = 2,
            NameEn = "Lipid Profile",
            NameAr = "دهون الدم",
            Price = 35.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 11,
            //Code = "URIC-ACID",
            CategoryId = 2,
            NameEn = "Uric Acid",
            NameAr = "حمض اليوريك",
            Price = 12.00m,
            IsActive = true
        },

        // =========================================================
        // HORMONES
        // =========================================================

        new LabTest
        {
            Id = 12,
            //Code = "TSH",
            CategoryId = 5,
            NameEn = "Thyroid Stimulating Hormone",
            NameAr = "الهرمون المنبه للغدة الدرقية",
            Price = 25.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 13,
            //Code = "FT4",
            CategoryId = 5,
            NameEn = "Free Thyroxine",
            NameAr = "الثيروكسين الحر",
            Price = 25.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 14,
            //Code = "BHCG",
            CategoryId = 5,
            NameEn = "Beta hCG",
            NameAr = "هرمون الحمل",
            Price = 20.00m,
            IsActive = true
        },

        // =========================================================
        // URINALYSIS
        // =========================================================

        new LabTest
        {
            Id = 15,
            //Code = "UA",
            CategoryId = 6,
            NameEn = "Urinalysis",
            NameAr = "تحليل البول",
            Price = 15.00m,
            IsActive = true
        },

        // =========================================================
        // SEROLOGY
        // =========================================================

        new LabTest
        {
            Id = 16,
            //Code = "WIDAL",
            CategoryId = 7,
            NameEn = "Widal Test",
            NameAr = "اختبار فيدال",
            Price = 15.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 17,
            //Code = "HBSAG",
            CategoryId = 7,
            NameEn = "Hepatitis B Surface Antigen",
            NameAr = "مستضد سطح التهاب الكبد B",
            Price = 20.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 18,
            //Code = "HCV",
            CategoryId = 7,
            NameEn = "Hepatitis C Antibody",
            NameAr = "الأجسام المضادة لالتهاب الكبد C",
            Price = 20.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 19,
            //Code = "HIV",
            CategoryId = 7,
            NameEn = "HIV Screening Test",
            NameAr = "فحص فيروس نقص المناعة البشرية",
            Price = 20.00m,
            IsActive = true
        },

        // =========================================================
        // PARASITOLOGY
        // =========================================================

        new LabTest
        {
            Id = 20,
            //Code = "MALARIA",
            CategoryId = 8,
            NameEn = "Malaria Test",
            NameAr = "فحص الملاريا",
            Price = 15.00m,
            IsActive = true
        },

        new LabTest
        {
            Id = 21,
            //Code = "STOOL",
            CategoryId = 8,
            NameEn = "Stool Examination",
            NameAr = "فحص البراز",
            Price = 15.00m,
            IsActive = true
        }
    };
        }
    }
}
