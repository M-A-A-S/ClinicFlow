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
    public class DoctorSpecialtyConfiguration
    : IEntityTypeConfiguration<DoctorSpecialty>
    {
        public void Configure(EntityTypeBuilder<DoctorSpecialty> builder)
        {
            builder.ToTable("DoctorSpecialties");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DoctorId)
                .IsRequired();

            builder.Property(x => x.SpecialtyId)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.DoctorSpecialties)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Specialty)
                .WithMany(x => x.DoctorSpecialties)
                .HasForeignKey(x => x.SpecialtyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new
            {
                x.DoctorId,
                x.SpecialtyId
            })
            .IsUnique()
            .HasDatabaseName("UX_DoctorSpecialties_DoctorId_SpecialtyId")
            .HasFilter("[IsDeleted] = 0");

            builder.HasData(LoadDoctorSpecialties());
        }

        private static List<DoctorSpecialty> LoadDoctorSpecialties()
        {
            return new()
    {
        // Dr. Ahmed Mohamed
        new DoctorSpecialty
        {
            Id = 1,
            DoctorId = 1,
            SpecialtyId = 1
        },
        new DoctorSpecialty
        {
            Id = 2,
            DoctorId = 1,
            SpecialtyId = 4
        },

        // Dr. Sara Ali
        new DoctorSpecialty
        {
            Id = 3,
            DoctorId = 2,
            SpecialtyId = 3
        },

        // Dr. Mohamed Hassan
        new DoctorSpecialty
        {
            Id = 4,
            DoctorId = 3,
            SpecialtyId = 6
        },
        new DoctorSpecialty
        {
            Id = 5,
            DoctorId = 3,
            SpecialtyId = 5
        },

        // Dr. Fatima Ahmed
        new DoctorSpecialty
        {
            Id = 6,
            DoctorId = 4,
            SpecialtyId = 10
        },

        // Dr. Khalid Osman
        new DoctorSpecialty
        {
            Id = 7,
            DoctorId = 5,
            SpecialtyId = 7
        },

        // Dr. Huda Ibrahim
        new DoctorSpecialty
        {
            Id = 8,
            DoctorId = 6,
            SpecialtyId = 2
        },

        // Dr. Yousif Omar
        new DoctorSpecialty
        {
            Id = 9,
            DoctorId = 7,
            SpecialtyId = 11
        },

        // Dr. Maryam Ibrahim
        new DoctorSpecialty
        {
            Id = 10,
            DoctorId = 8,
            SpecialtyId = 8
        }
    };
        }

    }
}
