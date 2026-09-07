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

    public class ClinicConfiguration
    : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("Clinics");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

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

            builder.HasData(LoadClinics());

        }

        private static List<Clinic> LoadClinics()
        {
            return new()
    {
        new Clinic
        {
            Id = 1,
            NameEn = "Internal Medicine Clinic",
            NameAr = "عيادة الباطنة",
            DescriptionEn = "Diagnosis and treatment of adult internal medicine conditions.",
            DescriptionAr = "تشخيص وعلاج أمراض الباطنة لدى البالغين.",
            IsActive = true
        },

        new Clinic
        {
            Id = 2,
            NameEn = "Cardiology Clinic",
            NameAr = "عيادة القلب",
            DescriptionEn = "Diagnosis and treatment of cardiovascular diseases.",
            DescriptionAr = "تشخيص وعلاج أمراض القلب والأوعية الدموية.",
            IsActive = true
        },

        new Clinic
        {
            Id = 3,
            NameEn = "Pediatric Clinic",
            NameAr = "عيادة الأطفال",
            DescriptionEn = "Medical care for infants, children, and adolescents.",
            DescriptionAr = "الرعاية الطبية للرضع والأطفال والمراهقين.",
            IsActive = true
        },

        new Clinic
        {
            Id = 4,
            NameEn = "Dental Clinic",
            NameAr = "عيادة الأسنان",
            DescriptionEn = "Diagnosis and treatment of dental and oral conditions.",
            DescriptionAr = "تشخيص وعلاج أمراض الأسنان والفم.",
            IsActive = true
        },

        new Clinic
        {
            Id = 5,
            NameEn = "Dermatology Clinic",
            NameAr = "عيادة الجلدية",
            DescriptionEn = "Diagnosis and treatment of skin, hair, and nail conditions.",
            DescriptionAr = "تشخيص وعلاج أمراض الجلد والشعر والأظافر.",
            IsActive = true
        },

        new Clinic
        {
            Id = 6,
            NameEn = "ENT Clinic",
            NameAr = "عيادة الأنف والأذن والحنجرة",
            DescriptionEn = "Diagnosis and treatment of ear, nose, and throat conditions.",
            DescriptionAr = "تشخيص وعلاج أمراض الأنف والأذن والحنجرة.",
            IsActive = true
        },

        new Clinic
        {
            Id = 7,
            NameEn = "Ophthalmology Clinic",
            NameAr = "عيادة العيون",
            DescriptionEn = "Diagnosis and treatment of eye and vision conditions.",
            DescriptionAr = "تشخيص وعلاج أمراض العيون ومشاكل النظر.",
            IsActive = true
        },

        new Clinic
        {
            Id = 8,
            NameEn = "General Practice Clinic",
            NameAr = "عيادة الطب العام",
            DescriptionEn = "Primary care for common medical conditions.",
            DescriptionAr = "الرعاية الأولية للحالات الطبية الشائعة.",
            IsActive = true
        }
    };
        }

    }

}
