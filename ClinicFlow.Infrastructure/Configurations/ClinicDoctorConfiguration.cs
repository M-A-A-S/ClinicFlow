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
    public class ClinicDoctorConfiguration
    : IEntityTypeConfiguration<ClinicDoctor>
    {
        public void Configure(EntityTypeBuilder<ClinicDoctor> builder)
        {
            builder.ToTable("ClinicDoctors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DoctorId)
                .IsRequired();

            builder.Property(x => x.ClinicId)
                .IsRequired();

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.ClinicDoctors)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Clinic)
                .WithMany(x => x.ClinicDoctors)
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.DoctorId,
                x.ClinicId
            })
            .IsUnique()
            .HasDatabaseName("UX_ClinicDoctors_Doctor_Clinic")
            .HasFilter("[IsDeleted] = 0");

            builder.HasData(LoadClinicDoctors());
        }

        private static List<ClinicDoctor> LoadClinicDoctors()
        {
            return new()
    {
        // Dr. Ahmed Hassan
        new ClinicDoctor
        {
            Id = 1,
            DoctorId = 1,
            ClinicId = 1
        },

        // Dr. Sara Mohamed
        new ClinicDoctor
        {
            Id = 2,
            DoctorId = 2,
            ClinicId = 2
        },

        // Dr. Omar Ali
        new ClinicDoctor
        {
            Id = 3,
            DoctorId = 3,
            ClinicId = 3
        },

        // Dr. Maryam Khalid
        new ClinicDoctor
        {
            Id = 4,
            DoctorId = 4,
            ClinicId = 4
        },

        // Dr. Youssef Ibrahim
        new ClinicDoctor
        {
            Id = 5,
            DoctorId = 5,
            ClinicId = 5
        },

        // Dr. Lina Ahmed
        new ClinicDoctor
        {
            Id = 6,
            DoctorId = 6,
            ClinicId = 6
        },

        // Dr. Ahmed Hassan also works in General Practice
        new ClinicDoctor
        {
            Id = 7,
            DoctorId = 1,
            ClinicId = 8
        },

        // Dr. Sara Mohamed also works in Internal Medicine
        new ClinicDoctor
        {
            Id = 8,
            DoctorId = 2,
            ClinicId = 1
        }
    };
        }

    }

}
