using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.DTOs.ChronicCondition;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class ChronicConditionExtensions
    {
        public static Expression<Func<ChronicCondition, ChronicConditionDTO>>
            ToDTOExpression => Entity => new ChronicConditionDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive
            };


        public static ChronicConditionDTO ToDTO(this ChronicCondition Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new ChronicConditionDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive
            };
        }

        public static ChronicCondition ToEntity(this ChronicConditionDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new ChronicCondition
            {
                Id = DTO.Id,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                DescriptionEn = DTO.DescriptionEn,
                DescriptionAr = DTO.DescriptionAr,
                IsActive = DTO.IsActive
            };
        }

        public static void UpdateEntity(this ChronicCondition Entity, ChronicConditionDTO DTO)
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
