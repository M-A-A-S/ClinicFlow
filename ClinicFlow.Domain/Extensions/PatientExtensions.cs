using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.DTOs.ChronicCondition;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.PatientAllergy;
using ClinicFlow.Domain.DTOs.PatientChronicCondition;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class PatientExtensions
    {
        public static Expression<Func<Patient, PatientDTO>>
            ToDTOExpression => Entity => new PatientDTO
            {
                Id = Entity.Id,
                FullName = Entity.FullName,
                PhoneNumber = Entity.PhoneNumber,
                Email = Entity.Email,
                Gender = Entity.Gender,
                NationalId = Entity.NationalId,
                Address = Entity.Address,
                DateOfBirth = Entity.DateOfBirth,
                BloodType = Entity.BloodType,
                IsActive = Entity.IsActive
            };


        public static PatientDTO ToDTO(this Patient Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new PatientDTO
            {
                Id = Entity.Id,
                FullName = Entity.FullName,
                PhoneNumber = Entity.PhoneNumber,
                Email = Entity.Email,
                Gender = Entity.Gender,
                NationalId = Entity.NationalId,
                Address = Entity.Address,
                DateOfBirth = Entity.DateOfBirth,
                BloodType = Entity.BloodType,
                IsActive = Entity.IsActive,

                PatientAllergies = Entity.PatientAllergies.Select(x => new PatientAllergyDTO
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    AllergyId = x.AllergyId,
                    IdentifiedAt = x.IdentifiedAt,
                    Notes = x.Notes,
                    Allergy = new AllergyDTO
                    {
                        Id = x.Allergy.Id,
                        NameEn = x.Allergy.NameEn,
                        NameAr = x.Allergy.NameAr,
                    }
                }).ToList(),

                PatientChronicConditions = Entity.PatientChronicConditions.Select(x => new PatientChronicConditionDTO
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    ChronicConditionId = x.ChronicConditionId,
                    DiagnosedAt = x.DiagnosedAt,
                    Notes = x.Notes,
                    ChronicCondition = new ChronicConditionDTO
                    {
                        Id = x.ChronicCondition.Id,
                        NameEn = x.ChronicCondition.NameEn,
                        NameAr = x.ChronicCondition.NameAr,
                    }
                }).ToList()
            };
        }

        public static Patient ToEntity(this PatientDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Patient
            {
                Id = DTO.Id,
                FullName = DTO.FullName,
                PhoneNumber = DTO.PhoneNumber,
                Email = DTO.Email,
                Gender = DTO.Gender,
                NationalId = DTO.NationalId,
                Address = DTO.Address,
                DateOfBirth = DTO.DateOfBirth,
                BloodType = DTO.BloodType,
                IsActive = DTO.IsActive,

                PatientAllergies = DTO.PatientAllergies
                    .Select(x => new PatientAllergy
                    {
                        AllergyId = x.AllergyId,
                        Notes = x.Notes,
                        IdentifiedAt = x.IdentifiedAt
                    }).ToList(),

                PatientChronicConditions = DTO.PatientChronicConditions
                    .Select(x => new PatientChronicCondition
                    {
                        ChronicConditionId = x.ChronicConditionId,
                        Notes = x.Notes,
                        DiagnosedAt = x.DiagnosedAt
                    }).ToList()
            };
        }

        public static void UpdateEntity(
            this Patient Entity, 
            PatientDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.FullName = DTO.FullName;
            Entity.PhoneNumber = DTO.PhoneNumber;
            Entity.Email = DTO.Email;
            Entity.Gender = DTO.Gender;
            Entity.NationalId = DTO.NationalId;
            Entity.Address = DTO.Address;
            Entity.DateOfBirth = DTO.DateOfBirth;
            Entity.BloodType = DTO.BloodType;
            Entity.IsActive = DTO.IsActive;

            Entity.UpdatedAt = DateTime.UtcNow;
        }

    }
}
