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
    public class SpecialtyConfiguration
    : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.ToTable("Specialties");

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

            //builder.HasIndex(x => x.NameEn)
            //    .IsUnique()
            //    .HasDatabaseName("UX_Specialties_NameEn")
            //    .HasFilter("[IsDeleted] = 0");

            //builder.HasIndex(x => x.NameAr)
            //    .IsUnique()
            //    .HasDatabaseName("UX_Specialties_NameAr")
            //    .HasFilter("[IsDeleted] = 0");

            //builder.HasMany<DoctorSpecialty>()
            //    .WithOne(x => x.Specialty)
            //    .HasForeignKey(x => x.SpecialtyId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(LoadSpecialties());
        }

        private static List<Specialty> LoadSpecialties()
        {
            return new()
        {
            new Specialty
            {
                Id = 1,
                NameEn = "Cardiology",
                NameAr = "أمراض القلب",
                DescriptionEn = "Diagnosis and treatment of heart and cardiovascular diseases",
                DescriptionAr = "تشخيص وعلاج أمراض القلب والأوعية الدموية",
                IsActive = true
            },

            new Specialty
            {
                Id = 2,
                NameEn = "Dermatology",
                NameAr = "الأمراض الجلدية",
                DescriptionEn = "Diagnosis and treatment of skin, hair, and nail conditions",
                DescriptionAr = "تشخيص وعلاج أمراض الجلد والشعر والأظافر",
                IsActive = true
            },

            new Specialty
            {
                Id = 3,
                NameEn = "Pediatrics",
                NameAr = "طب الأطفال",
                DescriptionEn = "Medical care for infants, children, and adolescents",
                DescriptionAr = "الرعاية الطبية للرضع والأطفال والمراهقين",
                IsActive = true
            },

            new Specialty
            {
                Id = 4,
                NameEn = "Internal Medicine",
                NameAr = "الطب الباطني",
                DescriptionEn = "Diagnosis and treatment of diseases affecting internal organs",
                DescriptionAr = "تشخيص وعلاج الأمراض التي تصيب الأعضاء الداخلية",
                IsActive = true
            },

            new Specialty
            {
                Id = 5,
                NameEn = "General Surgery",
                NameAr = "الجراحة العامة",
                DescriptionEn = "Surgical treatment of a wide range of medical conditions",
                DescriptionAr = "العلاج الجراحي لمجموعة واسعة من الحالات الطبية",
                IsActive = true
            },

            new Specialty
            {
                Id = 6,
                NameEn = "Orthopedics",
                NameAr = "جراحة العظام",
                DescriptionEn = "Diagnosis and treatment of musculoskeletal conditions",
                DescriptionAr = "تشخيص وعلاج أمراض وإصابات الجهاز العضلي الهيكلي",
                IsActive = true
            },

            new Specialty
            {
                Id = 7,
                NameEn = "Neurology",
                NameAr = "طب الأعصاب",
                DescriptionEn = "Diagnosis and treatment of disorders of the nervous system",
                DescriptionAr = "تشخيص وعلاج اضطرابات الجهاز العصبي",
                IsActive = true
            },

            new Specialty
            {
                Id = 8,
                NameEn = "Ophthalmology",
                NameAr = "طب العيون",
                DescriptionEn = "Diagnosis and treatment of eye diseases and vision disorders",
                DescriptionAr = "تشخيص وعلاج أمراض العيون واضطرابات الرؤية",
                IsActive = true
            },

            new Specialty
            {
                Id = 9,
                NameEn = "Dentistry",
                NameAr = "طب الأسنان",
                DescriptionEn = "Prevention, diagnosis, and treatment of dental conditions",
                DescriptionAr = "الوقاية وتشخيص وعلاج أمراض الأسنان والفم",
                IsActive = true
            },

            new Specialty
            {
                Id = 10,
                NameEn = "Obstetrics and Gynecology",
                NameAr = "النساء والتوليد",
                DescriptionEn = "Medical care related to pregnancy, childbirth, and women's reproductive health",
                DescriptionAr = "الرعاية الطبية المتعلقة بالحمل والولادة وصحة المرأة الإنجابية",
                IsActive = true
            },

            new Specialty
            {
                Id = 11,
                NameEn = "ENT",
                NameAr = "الأنف والأذن والحنجرة",
                DescriptionEn = "Diagnosis and treatment of ear, nose, and throat conditions",
                DescriptionAr = "تشخيص وعلاج أمراض الأنف والأذن والحنجرة",
                IsActive = true
            },

            new Specialty
            {
                Id = 12,
                NameEn = "Psychiatry",
                NameAr = "الطب النفسي",
                DescriptionEn = "Diagnosis and treatment of mental health conditions",
                DescriptionAr = "تشخيص وعلاج اضطرابات الصحة النفسية",
                IsActive = true
            }
        };
        }
    }
}
