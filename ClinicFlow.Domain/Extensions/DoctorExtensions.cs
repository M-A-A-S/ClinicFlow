using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.DTOs.ChronicCondition;
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
    public static class DoctorExtensions
    {
        public static Expression<Func<Doctor, DoctorDTO>>
            ToDTOExpression => Entity => new DoctorDTO
            {
                Id = Entity.Id,
                FullName = Entity.FullName,
                PhoneNumber = Entity.PhoneNumber,
                Email = Entity.Email,
                ConsultationFee = Entity.ConsultationFee,
                IsActive = Entity.IsActive
            };


        public static DoctorDTO ToDTO(this Doctor Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new DoctorDTO
            {
                Id = Entity.Id,
                FullName = Entity.FullName,
                PhoneNumber = Entity.PhoneNumber,
                Email = Entity.Email,
                ConsultationFee = Entity.ConsultationFee,
                IsActive = Entity.IsActive,

                DoctorSpecialties = Entity.DoctorSpecialties.Select(x => new DoctorSpecialtyDTO
                {
                    Id = x.Id,
                    DoctorId = x.DoctorId,
                    SpecialtyId = x.SpecialtyId,
                    Specialty = new SpecialtyDTO
                    {
                        Id = x.Specialty.Id,
                        NameEn = x.Specialty.NameEn,
                        NameAr = x.Specialty.NameAr,
                    }
                }).ToList()
            };
        }

        public static Doctor ToEntity(this DoctorDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Doctor
            {
                Id = DTO.Id,
                FullName = DTO.FullName,
                PhoneNumber = DTO.PhoneNumber,
                Email = DTO.Email,
                ConsultationFee = DTO.ConsultationFee,
                IsActive = DTO.IsActive,

                DoctorSpecialties = DTO.DoctorSpecialties
                    .Select(x => new DoctorSpecialty
                    {
                        SpecialtyId = x.SpecialtyId,
                    }).ToList(),

            };
        }

        public static void UpdateEntity(
            this Doctor Entity,
            DoctorDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.FullName = DTO.FullName;
            Entity.PhoneNumber = DTO.PhoneNumber;
            Entity.Email = DTO.Email;
            Entity.ConsultationFee = DTO.ConsultationFee;
            Entity.IsActive = DTO.IsActive;

            Entity.UpdatedAt = DateTime.UtcNow;
        }

    }
}
