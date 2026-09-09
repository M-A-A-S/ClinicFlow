using ClinicFlow.Domain.DTOs.Medicine;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class MedicineExtensions
    {
        public static Expression<Func<Medicine, MedicineDTO>>
            ToDTOExpression => Entity => new MedicineDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                GenericNameEn = Entity.GenericNameEn,
                GenericNameAr = Entity.GenericNameAr,
                Strength = Entity.Strength,
                DosageForm = Entity.DosageForm,
                Route = Entity.Route,
                IsActive = Entity.IsActive
            };


        public static MedicineDTO ToDTO(this Medicine Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new MedicineDTO
            {
                Id = Entity.Id,
                NameEn = Entity.NameEn,
                NameAr = Entity.NameAr,
                GenericNameEn = Entity.GenericNameEn,
                GenericNameAr = Entity.GenericNameAr,
                Strength = Entity.Strength,
                DosageForm = Entity.DosageForm,
                Route = Entity.Route,
                IsActive = Entity.IsActive
            };
        }

        public static Medicine ToEntity(this MedicineDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Medicine
            {
                Id = DTO.Id,
                NameEn = DTO.NameEn,
                NameAr = DTO.NameAr,
                GenericNameEn = DTO.GenericNameEn,
                GenericNameAr = DTO.GenericNameAr,
                Strength = DTO.Strength,
                DosageForm = DTO.DosageForm,
                Route = DTO.Route,
                IsActive = DTO.IsActive
            };
        }

        public static void UpdateEntity(this Medicine Entity, MedicineDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.NameEn = DTO.NameEn;
            Entity.NameAr = DTO.NameAr;
            Entity.GenericNameEn = DTO.GenericNameEn;
            Entity.GenericNameAr = DTO.GenericNameAr;
            Entity.Strength = DTO.Strength;
            Entity.DosageForm = DTO.DosageForm;
            Entity.Route = DTO.Route;
            Entity.IsActive = DTO.IsActive;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
