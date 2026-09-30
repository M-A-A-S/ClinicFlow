using ClinicFlow.Domain.DTOs.BondCategory;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class BondCategoryExtensions
    {
        public static Expression<Func<BondCategory, BondCategoryDTO>>
            ToDTOExpression => Entity => new BondCategoryDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                Type = Entity.Type,
                IsActive = Entity.IsActive
            };


        public static BondCategoryDTO ToDTO(this BondCategory Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new BondCategoryDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                Type = Entity.Type,
                IsActive = Entity.IsActive
            };
        }

        public static BondCategory ToEntity(this BondCategoryDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new BondCategory
            {
                Id = DTO.Id,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                Type = DTO.Type,
                IsActive = DTO.IsActive
            };
        }

        public static void UpdateEntity(this BondCategory Entity, BondCategoryDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.NameEn = DTO.NameEn;
            Entity.NameAr = DTO.NameAr;
            Entity.Type = DTO.Type;
            Entity.IsActive = DTO.IsActive;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
