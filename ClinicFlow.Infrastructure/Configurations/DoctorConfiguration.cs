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
    public class DoctorConfiguration
    : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.ConsultationFee)
                .HasPrecision(18, 2)
                .IsRequired(true);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            //builder.HasIndex(x => x.FullName)
            //    .HasDatabaseName("IX_Doctors_FullName")
            //    .HasFilter("[IsDeleted] = 0");

            //builder.HasIndex(x => x.Email)
            //    .HasDatabaseName("IX_Doctors_Email")
            //    .HasFilter("[IsDeleted] = 0 AND [Email] IS NOT NULL");

            //builder.HasMany(x => x.DoctorSpecialties)
            //    .WithOne(x => x.Doctor)
            //    .HasForeignKey(x => x.DoctorId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(LoadDoctors());
        }

        private static List<Doctor> LoadDoctors()
        {
            return new()
    {
        new Doctor
        {
            Id = 1,
            FullName = "Dr. Ahmed Mohamed",
            PhoneNumber = "0912345678",
            Email = "ahmed.mohamed@clinic.com",
            ConsultationFee = 50.00m,
            IsActive = true
        },

        new Doctor
        {
            Id = 2,
            FullName = "Dr. Sara Ali",
            PhoneNumber = "0923456789",
            Email = "sara.ali@clinic.com",
            ConsultationFee = 60.00m,
            IsActive = true
        },

        new Doctor
        {
            Id = 3,
            FullName = "Dr. Mohamed Hassan",
            PhoneNumber = "0934567890",
            Email = "mohamed.hassan@clinic.com",
            ConsultationFee = 45.00m,
            IsActive = true
        },

        new Doctor
        {
            Id = 4,
            FullName = "Dr. Fatima Ahmed",
            PhoneNumber = "0945678901",
            Email = "fatima.ahmed@clinic.com",
            ConsultationFee = 55.00m,
            IsActive = true
        },

        new Doctor
        {
            Id = 5,
            FullName = "Dr. Khalid Osman",
            PhoneNumber = "0956789012",
            Email = "khalid.osman@clinic.com",
            ConsultationFee = 50.00m,
            IsActive = true
        },

        new Doctor
        {
            Id = 6,
            FullName = "Dr. Huda Ibrahim",
            PhoneNumber = "0967890123",
            Email = "huda.ibrahim@clinic.com",
            ConsultationFee = 65.00m,
            IsActive = true
        },

        new Doctor
        {
            Id = 7,
            FullName = "Dr. Yousif Omar",
            PhoneNumber = "0978901234",
            Email = "yousif.omar@clinic.com",
            ConsultationFee = 50.00m,
            IsActive = true
        },

        new Doctor
        {
            Id = 8,
            FullName = "Dr. Maryam Ibrahim",
            PhoneNumber = "0989012345",
            Email = "maryam.ibrahim@clinic.com",
            ConsultationFee = 70.00m,
            IsActive = true
        }
    };
        }

    }
}
