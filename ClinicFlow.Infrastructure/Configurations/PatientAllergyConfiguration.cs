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
    public class PatientAllergyConfiguration
        : IEntityTypeConfiguration<PatientAllergy>
    {
        public void Configure(EntityTypeBuilder<PatientAllergy> builder)
        {
            builder.ToTable("PatientAllergies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Notes)
                .HasMaxLength(1000);

            builder.Property(x => x.IdentifiedAt);

            builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.PatientAllergies)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Allergy)
                .WithMany(x => x.PatientAllergies)
                .HasForeignKey(x => x.AllergyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.PatientId,
                x.AllergyId
            })
            .IsUnique()
            .HasDatabaseName("UX_PatientAllergies_Patient_Allergy")
            .HasFilter("[IsDeleted] = 0");

            builder.HasData(LoadPatientAllergies());

        }

        private static List<PatientAllergy> LoadPatientAllergies()
        {
            return new()
        {
            new PatientAllergy
            {
                Id = 1,
                PatientId = 1,
                AllergyId = 1,
                Notes = "Known penicillin allergy",
                IdentifiedAt = new DateTime(2020, 5, 10)
            },

            new PatientAllergy
            {
                Id = 2,
                PatientId = 1,
                AllergyId = 4,
                Notes = "Avoid latex products",
                IdentifiedAt = new DateTime(2021, 3, 15)
            },

            new PatientAllergy
            {
                Id = 3,
                PatientId = 2,
                AllergyId = 2,
                Notes = "Reported by patient",
                IdentifiedAt = new DateTime(2019, 8, 20)
            },

            new PatientAllergy
            {
                Id = 4,
                PatientId = 3,
                AllergyId = 5,
                Notes = "Food allergy",
                IdentifiedAt = new DateTime(2018, 6, 5)
            }
        };

        }
    }
}
