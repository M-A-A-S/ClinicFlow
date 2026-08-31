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
    public class ChronicConditionConfiguration
        : IEntityTypeConfiguration<ChronicCondition>
    {
        public void Configure(EntityTypeBuilder<ChronicCondition> builder)
        {
            builder.ToTable("ChronicConditions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.NameAr)
                .IsRequired(false)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

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
                .HasDatabaseName("UX_ChronicConditions_NameEn")
                .HasFilter("[IsDeleted] = 0");

            builder.HasIndex(x => x.NameAr)
                .IsUnique()
                .HasDatabaseName("UX_ChronicConditions_NameAr")
                .HasFilter("[IsDeleted] = 0");

            builder.HasData(LoadChronicConditions());
        }

        private static List<ChronicCondition> LoadChronicConditions()
        {
            return new()
    {
        new ChronicCondition
        {
            Id = 1,
            NameEn = "Diabetes Mellitus",
            NameAr = "داء السكري",
            DescriptionEn = "A metabolic disorder characterized by elevated blood glucose levels",
            DescriptionAr = "اضطراب أيضي يتميز بارتفاع مستوى سكر الدم",
            IsActive = true
        },
        new ChronicCondition
        {
            Id = 2,
            NameEn = "Hypertension",
            NameAr = "ارتفاع ضغط الدم",
            DescriptionEn = "Persistently elevated blood pressure",
            DescriptionAr = "ارتفاع مستمر في ضغط الدم",
            IsActive = true
        },
        new ChronicCondition
        {
            Id = 3,
            NameEn = "Asthma",
            NameAr = "الربو",
            DescriptionEn = "A chronic respiratory condition affecting the airways",
            DescriptionAr = "حالة تنفسية مزمنة تؤثر على الشعب الهوائية",
            IsActive = true
        },
        new ChronicCondition
        {
            Id = 4,
            NameEn = "Chronic Kidney Disease",
            NameAr = "مرض الكلى المزمن",
            DescriptionEn = "Long-term impairment of kidney function",
            DescriptionAr = "ضعف طويل الأمد في وظائف الكلى",
            IsActive = true
        },
        new ChronicCondition
        {
            Id = 5,
            NameEn = "Heart Disease",
            NameAr = "أمراض القلب",
            DescriptionEn = "A chronic condition affecting the heart",
            DescriptionAr = "حالة مزمنة تؤثر على القلب",
            IsActive = true
        },
        new ChronicCondition
        {
            Id = 6,
            NameEn = "Thyroid Disorder",
            NameAr = "اضطراب الغدة الدرقية",
            DescriptionEn = "A disorder affecting thyroid function",
            DescriptionAr = "اضطراب يؤثر على وظائف الغدة الدرقية",
            IsActive = true
        },
        new ChronicCondition
        {
            Id = 7,
            NameEn = "Chronic Obstructive Pulmonary Disease",
            NameAr = "مرض الانسداد الرئوي المزمن",
            DescriptionEn = "A chronic lung disease causing airflow limitation",
            DescriptionAr = "مرض رئوي مزمن يسبب محدودية تدفق الهواء",
            IsActive = true
        }
    };
        }
    
    }
}
