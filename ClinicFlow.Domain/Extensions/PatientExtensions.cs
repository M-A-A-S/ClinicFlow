using ClinicFlow.Domain.DTOs.Patient;
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
                IsActive = Entity.IsActive
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

        public static void UpdateEntity(this Patient Entity, PatientDTO DTO)
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

            Entity.PatientAllergies.Clear();

            foreach (var allergy in DTO.PatientAllergies)
            {
                Entity.PatientAllergies.Add(new PatientAllergy
                {
                    AllergyId = allergy.AllergyId,
                    Notes = allergy.Notes,
                    IdentifiedAt = allergy.IdentifiedAt
                });
            }

            Entity.PatientChronicConditions.Clear();

            foreach (var condition in DTO.PatientChronicConditions)
            {
                Entity.PatientChronicConditions.Add(new PatientChronicCondition
                {
                    ChronicConditionId = condition.ChronicConditionId,
                    Notes = condition.Notes,
                    DiagnosedAt = condition.DiagnosedAt
                });
            }

        }

    }
}
