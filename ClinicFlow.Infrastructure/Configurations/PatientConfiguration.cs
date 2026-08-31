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
    public class PatientConfiguration
        : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(30);

            builder.Property(x => x.Email)
                .HasMaxLength(254);

            builder.Property(x => x.NationalId)
                .HasMaxLength(50);

            builder.Property(x => x.Address)
                .HasMaxLength(500);

            builder.Property(x => x.BloodType)
            .HasConversion<int>();

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

            builder.HasIndex(x => x.PhoneNumber)
                .HasDatabaseName("IX_Patients_PhoneNumber")
                .HasFilter("[PhoneNumber] IS NOT NULL AND [IsDeleted] = 0");

            builder.HasIndex(x => x.Email)
                .HasDatabaseName("IX_Patients_Email")
                .HasFilter("[Email] IS NOT NULL AND [IsDeleted] = 0");

            builder.HasIndex(x => x.NationalId)
                .IsUnique()
                .HasDatabaseName("UX_Patients_NationalId")
                .HasFilter("[NationalId] IS NOT NULL AND [IsDeleted] = 0");

            builder.HasData(LoadPatients());


        }

        private static List<Patient> LoadPatients()
        {
            return new()
        {
            new Patient
            {
                Id = 1,
                FullName = "Ahmed Hassan",
                PhoneNumber = "0912345678",
                Email = "ahmed.hassan@example.com",
                Gender = Gender.Male,
                NationalId = "1234567890",
                Address = "Khartoum",
                DateOfBirth = new DateTime(1985, 4, 12),
                BloodType = BloodType.OPositive,
                IsActive = true
            },

            new Patient
            {
                Id = 2,
                FullName = "Sara Mohamed",
                PhoneNumber = "0998765432",
                Email = "sara.mohamed@example.com",
                Gender = Gender.Female,
                NationalId = "0987654321",
                Address = "Omdurman",
                DateOfBirth = new DateTime(1992, 8, 25),
                BloodType = BloodType.APositive,
                IsActive = true
            },

            new Patient
            {
                Id = 3,
                FullName = "Mohamed Ali",
                PhoneNumber = "0911223344",
                Email = "mohamed.ali@example.com",
                Gender = Gender.Male,
                NationalId = "1122334455",
                Address = "Bahri",
                DateOfBirth = new DateTime(1978, 11, 5),
                BloodType = BloodType.BPositive,
                IsActive = true
            },

            new Patient
            {
                Id = 4,
                FullName = "Fatima Ahmed",
                PhoneNumber = "0922334455",
                Email = "fatima.ahmed@example.com",
                Gender = Gender.Female,
                NationalId = "2233445566",
                Address = "Khartoum",
                DateOfBirth = new DateTime(2000, 2, 18),
                BloodType = BloodType.ABNegative,
                IsActive = true
            },

            new Patient
            {
                Id = 5,
                FullName = "Omar Ibrahim",
                PhoneNumber = "0933445566",
                Email = "omar.ibrahim@example.com",
                Gender = Gender.Male,
                NationalId = "3344556677",
                Address = "Omdurman",
                DateOfBirth = new DateTime(1969, 7, 30),
                BloodType = BloodType.ONegative,
                IsActive = true
            }
        };

        }
    }
}
