using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class AllergyExtensions
    {
        public static Expression<Func<Allergy, AllergyDTO>>
            ToDTOExpression => Entity => new AllergyDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive
            };


        public static AllergyDTO ToDTO(this Allergy Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new AllergyDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                DescriptionEn = Entity.DescriptionEn,
                DescriptionAr = Entity.DescriptionAr,
                IsActive = Entity.IsActive
            };
        }

        public static Allergy ToEntity(this AllergyDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Allergy
            {
                Id = DTO.Id,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                DescriptionEn = DTO.DescriptionEn,
                DescriptionAr = DTO.DescriptionAr,
                IsActive = DTO.IsActive
            };
        }

        public static void UpdateEntity(this Allergy Entity, AllergyDTO DTO)
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
