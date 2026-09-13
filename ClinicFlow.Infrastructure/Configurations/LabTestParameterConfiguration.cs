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
    public class LabTestParameterConfiguration
    : IEntityTypeConfiguration<LabTestParameter>
    {
        public void Configure(EntityTypeBuilder<LabTestParameter> builder)
        {
            builder.ToTable("LabTestParameters");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.NameAr)
                .IsRequired(false)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(x => x.Unit)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(x => x.NormalRange)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.LabTestId,
                x.DisplayOrder
            })
            .IsUnique()
            .HasDatabaseName("UX_LabTestParameters_Test_DisplayOrder")
            .HasFilter("[IsDeleted] = 0");

            builder.HasData(LoadParameters());
        }

        private static List<LabTestParameter> LoadParameters()
        {
            return new()
    {
        // =========================================================
        // CBC - LabTestId = 1
        // =========================================================

        new LabTestParameter
        {
            Id = 1,
            LabTestId = 1,
            NameEn = "Hemoglobin",
            NameAr = "الهيموغلوبين",
            Unit = "g/dL",
            NormalRange = "Male: 13.0 - 17.0; Female: 12.0 - 15.0",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 2,
            LabTestId = 1,
            NameEn = "White Blood Cell Count",
            NameAr = "عدد كريات الدم البيضاء",
            Unit = "10^3/µL",
            NormalRange = "4.0 - 11.0",
            DisplayOrder = 2,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 3,
            LabTestId = 1,
            NameEn = "Red Blood Cell Count",
            NameAr = "عدد كريات الدم الحمراء",
            Unit = "10^6/µL",
            NormalRange = "Male: 4.5 - 5.9; Female: 4.0 - 5.2",
            DisplayOrder = 3,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 4,
            LabTestId = 1,
            NameEn = "Hematocrit",
            NameAr = "الهيماتوكريت",
            Unit = "%",
            NormalRange = "Male: 41 - 53; Female: 36 - 46",
            DisplayOrder = 4,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 5,
            LabTestId = 1,
            NameEn = "Mean Corpuscular Volume",
            NameAr = "متوسط حجم كريات الدم الحمراء",
            Unit = "fL",
            NormalRange = "80 - 100",
            DisplayOrder = 5,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 6,
            LabTestId = 1,
            NameEn = "Mean Corpuscular Hemoglobin",
            NameAr = "متوسط هيموغلوبين الكرية",
            Unit = "pg",
            NormalRange = "27 - 33",
            DisplayOrder = 6,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 7,
            LabTestId = 1,
            NameEn = "Mean Corpuscular Hemoglobin Concentration",
            NameAr = "متوسط تركيز هيموغلوبين الكرية",
            Unit = "g/dL",
            NormalRange = "32 - 36",
            DisplayOrder = 7,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 8,
            LabTestId = 1,
            NameEn = "Platelet Count",
            NameAr = "عدد الصفائح الدموية",
            Unit = "10^3/µL",
            NormalRange = "150 - 450",
            DisplayOrder = 8,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 9,
            LabTestId = 1,
            NameEn = "Neutrophils",
            NameAr = "العدلات",
            Unit = "%",
            NormalRange = "40 - 70",
            DisplayOrder = 9,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 10,
            LabTestId = 1,
            NameEn = "Lymphocytes",
            NameAr = "الخلايا اللمفاوية",
            Unit = "%",
            NormalRange = "20 - 40",
            DisplayOrder = 10,
            IsActive = true
        },

        // =========================================================
        // ESR - LabTestId = 2
        // =========================================================

        new LabTestParameter
        {
            Id = 11,
            LabTestId = 2,
            NameEn = "Erythrocyte Sedimentation Rate",
            NameAr = "سرعة ترسيب كريات الدم الحمراء",
            Unit = "mm/hr",
            NormalRange = "Male: 0 - 15; Female: 0 - 20",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // HEMOGLOBIN - LabTestId = 3
        // =========================================================

        new LabTestParameter
        {
            Id = 12,
            LabTestId = 3,
            NameEn = "Hemoglobin",
            NameAr = "الهيموغلوبين",
            Unit = "g/dL",
            NormalRange = "Male: 13.0 - 17.0; Female: 12.0 - 15.0",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // BLOOD GROUP - LabTestId = 4
        // =========================================================

        new LabTestParameter
        {
            Id = 13,
            LabTestId = 4,
            NameEn = "ABO Blood Group",
            NameAr = "فصيلة الدم ABO",
            Unit = null,
            NormalRange = "A, B, AB, O",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 14,
            LabTestId = 4,
            NameEn = "Rh Factor",
            NameAr = "عامل ريسوس",
            Unit = null,
            NormalRange = "Positive / Negative",
            DisplayOrder = 2,
            IsActive = true
        },

        // =========================================================
        // LFT - LabTestId = 5
        // =========================================================

        new LabTestParameter
        {
            Id = 15,
            LabTestId = 5,
            NameEn = "ALT",
            NameAr = "إنزيم ALT",
            Unit = "U/L",
            NormalRange = "7 - 56",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 16,
            LabTestId = 5,
            NameEn = "AST",
            NameAr = "إنزيم AST",
            Unit = "U/L",
            NormalRange = "10 - 40",
            DisplayOrder = 2,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 17,
            LabTestId = 5,
            NameEn = "Alkaline Phosphatase",
            NameAr = "الفوسفاتاز القلوي",
            Unit = "U/L",
            NormalRange = "44 - 147",
            DisplayOrder = 3,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 18,
            LabTestId = 5,
            NameEn = "Total Bilirubin",
            NameAr = "البيليروبين الكلي",
            Unit = "mg/dL",
            NormalRange = "0.1 - 1.2",
            DisplayOrder = 4,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 19,
            LabTestId = 5,
            NameEn = "Direct Bilirubin",
            NameAr = "البيليروبين المباشر",
            Unit = "mg/dL",
            NormalRange = "0.0 - 0.3",
            DisplayOrder = 5,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 20,
            LabTestId = 5,
            NameEn = "Albumin",
            NameAr = "الألبومين",
            Unit = "g/dL",
            NormalRange = "3.5 - 5.0",
            DisplayOrder = 6,
            IsActive = true
        },

        // =========================================================
        // KFT - LabTestId = 6
        // =========================================================

        new LabTestParameter
        {
            Id = 21,
            LabTestId = 6,
            NameEn = "Creatinine",
            NameAr = "الكرياتينين",
            Unit = "mg/dL",
            NormalRange = "Male: 0.74 - 1.35; Female: 0.59 - 1.04",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 22,
            LabTestId = 6,
            NameEn = "Urea",
            NameAr = "اليوريا",
            Unit = "mg/dL",
            NormalRange = "15 - 45",
            DisplayOrder = 2,
            IsActive = true
        },

        // =========================================================
        // FBS - LabTestId = 7
        // =========================================================

        new LabTestParameter
        {
            Id = 23,
            LabTestId = 7,
            NameEn = "Fasting Blood Glucose",
            NameAr = "سكر الدم الصائم",
            Unit = "mg/dL",
            NormalRange = "70 - 99",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // RBS - LabTestId = 8
        // =========================================================

        new LabTestParameter
        {
            Id = 24,
            LabTestId = 8,
            NameEn = "Random Blood Glucose",
            NameAr = "سكر الدم العشوائي",
            Unit = "mg/dL",
            NormalRange = "< 200",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // HbA1c - LabTestId = 9
        // =========================================================

        new LabTestParameter
        {
            Id = 25,
            LabTestId = 9,
            NameEn = "HbA1c",
            NameAr = "السكر التراكمي",
            Unit = "%",
            NormalRange = "4.0 - 5.6",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // LIPID PROFILE - LabTestId = 10
        // =========================================================

        new LabTestParameter
        {
            Id = 26,
            LabTestId = 10,
            NameEn = "Total Cholesterol",
            NameAr = "الكوليسترول الكلي",
            Unit = "mg/dL",
            NormalRange = "< 200",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 27,
            LabTestId = 10,
            NameEn = "HDL Cholesterol",
            NameAr = "الكوليسترول عالي الكثافة HDL",
            Unit = "mg/dL",
            NormalRange = "Male: > 40; Female: > 50",
            DisplayOrder = 2,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 28,
            LabTestId = 10,
            NameEn = "LDL Cholesterol",
            NameAr = "الكوليسترول منخفض الكثافة LDL",
            Unit = "mg/dL",
            NormalRange = "< 100",
            DisplayOrder = 3,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 29,
            LabTestId = 10,
            NameEn = "Triglycerides",
            NameAr = "الدهون الثلاثية",
            Unit = "mg/dL",
            NormalRange = "< 150",
            DisplayOrder = 4,
            IsActive = true
        },

        // =========================================================
        // URIC ACID - LabTestId = 11
        // =========================================================

        new LabTestParameter
        {
            Id = 30,
            LabTestId = 11,
            NameEn = "Uric Acid",
            NameAr = "حمض اليوريك",
            Unit = "mg/dL",
            NormalRange = "Male: 3.4 - 7.0; Female: 2.4 - 6.0",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // TSH - LabTestId = 12
        // =========================================================

        new LabTestParameter
        {
            Id = 31,
            LabTestId = 12,
            NameEn = "TSH",
            NameAr = "الهرمون المنبه للغدة الدرقية",
            Unit = "mIU/L",
            NormalRange = "0.4 - 4.0",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // FT4 - LabTestId = 13
        // =========================================================

        new LabTestParameter
        {
            Id = 32,
            LabTestId = 13,
            NameEn = "Free T4",
            NameAr = "الثيروكسين الحر",
            Unit = "ng/dL",
            NormalRange = "0.8 - 1.8",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // Beta hCG - LabTestId = 14
        // =========================================================

        new LabTestParameter
        {
            Id = 33,
            LabTestId = 14,
            NameEn = "Beta hCG",
            NameAr = "هرمون الحمل بيتا",
            Unit = "mIU/mL",
            NormalRange = "< 5",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // URINALYSIS - LabTestId = 15
        // =========================================================

        new LabTestParameter
        {
            Id = 34,
            LabTestId = 15,
            NameEn = "Color",
            NameAr = "اللون",
            Unit = null,
            NormalRange = "Yellow",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 35,
            LabTestId = 15,
            NameEn = "Appearance",
            NameAr = "المظهر",
            Unit = null,
            NormalRange = "Clear",
            DisplayOrder = 2,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 36,
            LabTestId = 15,
            NameEn = "Specific Gravity",
            NameAr = "الكثافة النوعية",
            Unit = null,
            NormalRange = "1.005 - 1.030",
            DisplayOrder = 3,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 37,
            LabTestId = 15,
            NameEn = "pH",
            NameAr = "درجة الحموضة",
            Unit = null,
            NormalRange = "5.0 - 8.0",
            DisplayOrder = 4,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 38,
            LabTestId = 15,
            NameEn = "Protein",
            NameAr = "البروتين",
            Unit = null,
            NormalRange = "Negative",
            DisplayOrder = 5,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 39,
            LabTestId = 15,
            NameEn = "Glucose",
            NameAr = "الجلوكوز",
            Unit = null,
            NormalRange = "Negative",
            DisplayOrder = 6,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 40,
            LabTestId = 15,
            NameEn = "Blood",
            NameAr = "الدم",
            Unit = null,
            NormalRange = "Negative",
            DisplayOrder = 7,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 41,
            LabTestId = 15,
            NameEn = "White Blood Cells",
            NameAr = "كريات الدم البيضاء",
            Unit = "/HPF",
            NormalRange = "0 - 5",
            DisplayOrder = 8,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 42,
            LabTestId = 15,
            NameEn = "Red Blood Cells",
            NameAr = "كريات الدم الحمراء",
            Unit = "/HPF",
            NormalRange = "0 - 2",
            DisplayOrder = 9,
            IsActive = true
        },

        // =========================================================
        // WIDAL - LabTestId = 16
        // =========================================================

        new LabTestParameter
        {
            Id = 43,
            LabTestId = 16,
            NameEn = "Salmonella O",
            NameAr = "السالمونيلا O",
            Unit = null,
            NormalRange = "Negative",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 44,
            LabTestId = 16,
            NameEn = "Salmonella H",
            NameAr = "السالمونيلا H",
            Unit = null,
            NormalRange = "Negative",
            DisplayOrder = 2,
            IsActive = true
        },

        // =========================================================
        // HBsAg - LabTestId = 17
        // =========================================================

        new LabTestParameter
        {
            Id = 45,
            LabTestId = 17,
            NameEn = "HBsAg",
            NameAr = "مستضد سطح التهاب الكبد B",
            Unit = null,
            NormalRange = "Non-reactive",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // HCV - LabTestId = 18
        // =========================================================

        new LabTestParameter
        {
            Id = 46,
            LabTestId = 18,
            NameEn = "HCV Antibody",
            NameAr = "الأجسام المضادة لالتهاب الكبد C",
            Unit = null,
            NormalRange = "Non-reactive",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // HIV - LabTestId = 19
        // =========================================================

        new LabTestParameter
        {
            Id = 47,
            LabTestId = 19,
            NameEn = "HIV Screening",
            NameAr = "فحص فيروس نقص المناعة البشرية",
            Unit = null,
            NormalRange = "Non-reactive",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // MALARIA - LabTestId = 20
        // =========================================================

        new LabTestParameter
        {
            Id = 48,
            LabTestId = 20,
            NameEn = "Malaria Parasite",
            NameAr = "طفيليات الملاريا",
            Unit = null,
            NormalRange = "Not detected",
            DisplayOrder = 1,
            IsActive = true
        },

        // =========================================================
        // STOOL - LabTestId = 21
        // =========================================================

        new LabTestParameter
        {
            Id = 49,
            LabTestId = 21,
            NameEn = "Color",
            NameAr = "اللون",
            Unit = null,
            NormalRange = "Brown",
            DisplayOrder = 1,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 50,
            LabTestId = 21,
            NameEn = "Consistency",
            NameAr = "القوام",
            Unit = null,
            NormalRange = "Formed",
            DisplayOrder = 2,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 51,
            LabTestId = 21,
            NameEn = "Occult Blood",
            NameAr = "الدم الخفي",
            Unit = null,
            NormalRange = "Negative",
            DisplayOrder = 3,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 52,
            LabTestId = 21,
            NameEn = "Ova",
            NameAr = "البيض",
            Unit = null,
            NormalRange = "Not detected",
            DisplayOrder = 4,
            IsActive = true
        },

        new LabTestParameter
        {
            Id = 53,
            LabTestId = 21,
            NameEn = "Parasites",
            NameAr = "الطفيليات",
            Unit = null,
            NormalRange = "Not detected",
            DisplayOrder = 5,
            IsActive = true
        }
    };
        }
    }
}
