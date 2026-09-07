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
    public class DiagnosisConfiguration
    : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.ToTable("Diagnoses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.DescriptionEn)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.DescriptionAr)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasData(LoadDiagnoses());

        }

        private static List<Diagnosis> LoadDiagnoses()
        {
            return new()
    {
        new Diagnosis
        {
            Id = 1,
            NameEn = "Essential hypertension",
            NameAr = "ارتفاع ضغط الدم الأساسي",
            DescriptionEn = "Primary hypertension without a specified secondary cause.",
            DescriptionAr = "ارتفاع ضغط الدم الأساسي دون سبب ثانوي محدد.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 2,
            NameEn = "Type 2 diabetes mellitus without complications",
            NameAr = "داء السكري من النوع الثاني دون مضاعفات",
            DescriptionEn = "Type 2 diabetes mellitus without documented complications.",
            DescriptionAr = "داء السكري من النوع الثاني دون مضاعفات مسجلة.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 3,
            NameEn = "Acute upper respiratory infection, unspecified",
            NameAr = "عدوى الجهاز التنفسي العلوي الحادة غير المحددة",
            DescriptionEn = "Acute upper respiratory infection without a specified cause.",
            DescriptionAr = "عدوى حادة في الجهاز التنفسي العلوي دون تحديد السبب.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 4,
            NameEn = "Asthma, unspecified",
            NameAr = "الربو غير المحدد",
            DescriptionEn = "Asthma without further specification.",
            DescriptionAr = "مرض الربو دون تحديد نوع أو تفاصيل إضافية.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 5,
            NameEn = "Hyperlipidemia, unspecified",
            NameAr = "فرط شحميات الدم غير المحدد",
            DescriptionEn = "Elevated blood lipids without further specification.",
            DescriptionAr = "ارتفاع مستوى الدهون في الدم دون تحديد إضافي.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 6,
            NameEn = "Gastro-esophageal reflux disease without esophagitis",
            NameAr = "مرض الارتجاع المعدي المريئي دون التهاب المريء",
            DescriptionEn = "Gastro-esophageal reflux disease without esophagitis.",
            DescriptionAr = "مرض الارتجاع المعدي المريئي دون التهاب في المريء.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 7,
            NameEn = "Low back pain",
            NameAr = "ألم أسفل الظهر",
            DescriptionEn = "Pain located in the lower back.",
            DescriptionAr = "ألم في منطقة أسفل الظهر.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 8,
            NameEn = "Migraine, unspecified",
            NameAr = "الصداع النصفي غير المحدد",
            DescriptionEn = "Migraine without further specification.",
            DescriptionAr = "الصداع النصفي دون تحديد إضافي.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 9,
            NameEn = "Pneumonia, unspecified organism",
            NameAr = "الالتهاب الرئوي غير المحدد",
            DescriptionEn = "Pneumonia without identification of the causative organism.",
            DescriptionAr = "التهاب رئوي دون تحديد الكائن المسبب.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 10,
            NameEn = "Urinary tract infection, site not specified",
            NameAr = "التهاب المسالك البولية غير المحدد",
            DescriptionEn = "Urinary tract infection without a specified site.",
            DescriptionAr = "التهاب في المسالك البولية دون تحديد الموقع.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 11,
            NameEn = "Atopic dermatitis, unspecified",
            NameAr = "التهاب الجلد التأتبي غير المحدد",
            DescriptionEn = "Atopic dermatitis without further specification.",
            DescriptionAr = "التهاب الجلد التأتبي دون تحديد إضافي.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 12,
            NameEn = "Conjunctivitis, unspecified",
            NameAr = "التهاب الملتحمة غير المحدد",
            DescriptionEn = "Inflammation of the conjunctiva without further specification.",
            DescriptionAr = "التهاب ملتحمة العين دون تحديد إضافي.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 13,
            NameEn = "Gastritis, unspecified",
            NameAr = "التهاب المعدة غير المحدد",
            DescriptionEn = "Inflammation of the stomach lining without further specification.",
            DescriptionAr = "التهاب بطانة المعدة دون تحديد إضافي.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 14,
            NameEn = "Anemia, unspecified",
            NameAr = "فقر الدم غير المحدد",
            DescriptionEn = "Anemia without further specification.",
            DescriptionAr = "فقر الدم دون تحديد نوعه.",
            IsActive = true
        },

        new Diagnosis
        {
            Id = 15,
            NameEn = "Hypothyroidism, unspecified",
            NameAr = "قصور الغدة الدرقية غير المحدد",
            DescriptionEn = "Hypothyroidism without further specification.",
            DescriptionAr = "قصور الغدة الدرقية دون تحديد إضافي.",
            IsActive = true
        }
    };
        }

    }
}
