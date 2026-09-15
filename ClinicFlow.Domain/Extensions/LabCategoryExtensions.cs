using ClinicFlow.Domain.DTOs.LabCategory;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class LabCategoryExtensions
    {
        public static Expression<Func<LabCategory, LabCategoryDTO>>
            ToDTOExpression => Entity => new LabCategoryDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                IsActive = Entity.IsActive
            };


        public static LabCategoryDTO ToDTO(this LabCategory Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new LabCategoryDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                IsActive = Entity.IsActive
            };
        }

        public static LabCategory ToEntity(this LabCategoryDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new LabCategory
            {
                Id = DTO.Id,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                IsActive = DTO.IsActive
            };
        }

        public static void UpdateEntity(this LabCategory Entity, LabCategoryDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.NameEn = DTO.NameEn;
            Entity.NameAr = DTO.NameAr;
            Entity.IsActive = DTO.IsActive;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
