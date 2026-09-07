using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.ClinicDoctor;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.DoctorSpecialty;
using ClinicFlow.Domain.DTOs.Specialty;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class ClinicExtensions
    {
        public static Expression<Func<Clinic, ClinicDTO>>
            ToDTOExpression => Entity => new ClinicDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive
            };


        public static ClinicDTO ToDTO(this Clinic Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new ClinicDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive,

                ClinicDoctors = Entity.ClinicDoctors.Select(x => new ClinicDoctorDTO
                {
                    Id = x.Id,
                    DoctorId = x.DoctorId,
                    ClinicId = x.ClinicId,
                    Doctor = new DoctorDTO
                    {
                        Id = x.Doctor.Id,
                        FullName = x.Doctor.FullName,
                        PhoneNumber = x.Doctor.PhoneNumber,
                    }
                }).ToList()

            };
        }

        public static Clinic ToEntity(this ClinicDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Clinic
            {
                Id = DTO.Id,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                DescriptionEn = DTO.DescriptionEn,
                DescriptionAr = DTO.DescriptionAr,
                IsActive = DTO.IsActive,

                ClinicDoctors = DTO.ClinicDoctors
                    .Select(x => new ClinicDoctor
                    {
                        DoctorId = x.DoctorId,
                    }).ToList(),

            };
        }

        public static void UpdateEntity(this Clinic Entity, ClinicDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.NameEn = DTO.NameEn;
            Entity.NameAr = DTO.NameAr;
            Entity.DescriptionEn = DTO.DescriptionEn;
            Entity.DescriptionAr = DTO.DescriptionAr;
            Entity.IsActive = DTO.IsActive;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
