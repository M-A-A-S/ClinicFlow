using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.LabCategory;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.LabTestParameter;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class LabTestExtensions
    {
        public static Expression<Func<LabTest, LabTestDTO>>
            ToDTOExpression => Entity => new LabTestDTO
            {
                Id = Entity.Id,
                CategoryId = Entity.CategoryId,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                Price = Entity.Price,
                IsActive = Entity.IsActive,

                Category = Entity.Category == null
                    ? null
                    : new LabCategoryDTO
                    {
                        Id = Entity.Category.Id,
                        NameEn = Entity.Category.NameEn,
                        NameAr = Entity.Category.NameAr,
                        IsActive = Entity.Category.IsActive,
                    },

                Parameters = Entity.Parameters
                    .Select(x => new LabTestParameterDTO
                    {
                        LabTestId = x.LabTestId,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                        Unit = x.Unit,
                        NormalRange = x.NormalRange,
                        DisplayOrder = x.DisplayOrder,
                        IsActive = x.IsActive
                    })
                .ToList()

            };


        public static LabTestDTO ToDTO(this LabTest Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new LabTestDTO
            {
                Id = Entity.Id,
                CategoryId = Entity.CategoryId,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                Price = Entity.Price,
                IsActive = Entity.IsActive,

                Category = Entity.Category == null
                    ? null
                    : new LabCategoryDTO
                    {
                        Id = Entity.Category.Id,
                        NameEn = Entity.Category.NameEn,
                        NameAr = Entity.Category.NameAr,
                        IsActive = Entity.Category.IsActive,
                    },

                Parameters = Entity.Parameters.Select(x => new LabTestParameterDTO
                {
                    LabTestId = x.LabTestId,
                    NameEn = x.NameEn,
                    NameAr = x.NameAr,
                    Unit = x.Unit,
                    NormalRange = x.NormalRange,
                    DisplayOrder = x.DisplayOrder,
                    IsActive = x.IsActive
                }).ToList()
            };
        }

        public static LabTest ToEntity(this LabTestDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new LabTest
            {
                Id = DTO.Id,
                CategoryId = DTO.CategoryId,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                Price = DTO.Price,
                IsActive = DTO.IsActive,
            };
        }

        public static void UpdateEntity(this LabTest Entity, LabTestDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.CategoryId = DTO.CategoryId;
            Entity.NameEn = DTO.NameEn;
            Entity.NameAr = DTO.NameAr;
            Entity.Price = DTO.Price;
            Entity.IsActive = DTO.IsActive;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
