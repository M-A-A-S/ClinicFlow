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
    public static class SpecialtyExtensions
    {
        public static Expression<Func<Specialty, SpecialtyDTO>>
            ToDTOExpression => Entity => new SpecialtyDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive
            };


        public static SpecialtyDTO ToDTO(this Specialty Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new SpecialtyDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive
            };
        }

        public static Specialty ToEntity(this SpecialtyDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Specialty
            {
                Id = DTO.Id,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                DescriptionEn = DTO.DescriptionEn,
                DescriptionAr = DTO.DescriptionAr,
                IsActive = DTO.IsActive
            };
        }

        public static void UpdateEntity(this Specialty Entity, SpecialtyDTO DTO)
        {
            //if (Entity == null || DTO == null)
            //{
            //    return;
            //}

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
