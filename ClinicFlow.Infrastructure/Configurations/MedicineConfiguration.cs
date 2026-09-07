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
    public class MedicineConfiguration
    : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicines");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.GenericNameEn)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.GenericNameAr)
                .IsRequired()
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.Strength)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.DosageForm)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Route)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasData(LoadMedicines());
        }
        
        private static List<Medicine> LoadMedicines()
        {
            return new List<Medicine>
            {
                new Medicine
                {
                    Id = 1,
                    NameEn = "Panadol 500 mg",
                    NameAr = "بنادول 500 ملغ",
                    GenericNameEn = "Paracetamol",
                    GenericNameAr = "باراسيتامول",
                    Strength = "500 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 2,
                    NameEn = "Amoxicillin 500 mg",
                    NameAr = "أموكسيسيلين 500 ملغ",
                    GenericNameEn = "Amoxicillin",
                    GenericNameAr = "أموكسيسيلين",
                    Strength = "500 mg",
                    DosageForm = "Capsule",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 3,
                    NameEn = "Ibuprofen 400 mg",
                    NameAr = "إيبوبروفين 400 ملغ",
                    GenericNameEn = "Ibuprofen",
                    GenericNameAr = "إيبوبروفين",
                    Strength = "400 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 4,
                    NameEn = "Omeprazole 20 mg",
                    NameAr = "أوميبرازول 20 ملغ",
                    GenericNameEn = "Omeprazole",
                    GenericNameAr = "أوميبرازول",
                    Strength = "20 mg",
                    DosageForm = "Capsule",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 5,
                    NameEn = "Metformin 500 mg",
                    NameAr = "ميتفورمين 500 ملغ",
                    GenericNameEn = "Metformin",
                    GenericNameAr = "ميتفورمين",
                    Strength = "500 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 6,
                    NameEn = "Amlodipine 5 mg",
                    NameAr = "أملوديبين 5 ملغ",
                    GenericNameEn = "Amlodipine",
                    GenericNameAr = "أملوديبين",
                    Strength = "5 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 7,
                    NameEn = "Cetirizine 10 mg",
                    NameAr = "سيتريزين 10 ملغ",
                    GenericNameEn = "Cetirizine",
                    GenericNameAr = "سيتريزين",
                    Strength = "10 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 8,
                    NameEn = "Salbutamol 100 mcg",
                    NameAr = "سالبوتامول 100 ميكروغرام",
                    GenericNameEn = "Salbutamol",
                    GenericNameAr = "سالبوتامول",
                    Strength = "100 mcg/dose",
                    DosageForm = "Inhaler",
                    Route = "Inhalation",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 9,
                    NameEn = "Diclofenac 50 mg",
                    NameAr = "ديكلوفيناك 50 ملغ",
                    GenericNameEn = "Diclofenac",
                    GenericNameAr = "ديكلوفيناك",
                    Strength = "50 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 10,
                    NameEn = "Azithromycin 500 mg",
                    NameAr = "أزيثروميسين 500 ملغ",
                    GenericNameEn = "Azithromycin",
                    GenericNameAr = "أزيثروميسين",
                    Strength = "500 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 11,
                    NameEn = "Loratadine 10 mg",
                    NameAr = "لوراتادين 10 ملغ",
                    GenericNameEn = "Loratadine",
                    GenericNameAr = "لوراتادين",
                    Strength = "10 mg",
                    DosageForm = "Tablet",
                    Route = "Oral",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Medicine
                {
                    Id = 12,
                    NameEn = "Hydrocortisone 1% Cream",
                    NameAr = "كريم هيدروكورتيزون 1%",
                    GenericNameEn = "Hydrocortisone",
                    GenericNameAr = "هيدروكورتيزون",
                    Strength = "1%",
                    DosageForm = "Cream",
                    Route = "Topical",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };
        }

    }
}
