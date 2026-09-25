using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class PaymentMethodExtensions
    {
        public static Expression<Func<PaymentMethod, PaymentMethodDTO>>
            ToDTOExpression => entity => new PaymentMethodDTO
            {
                Id = entity.Id,
                NameEn = entity.NameEn,
                NameAr = entity.NameAr,
                Type = entity.Type,
                IsActive = entity.IsActive
            };


        public static PaymentMethodDTO ToDTO(this PaymentMethod entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new PaymentMethodDTO
            {
                Id = entity.Id,
                NameEn = entity.NameEn,
                NameAr = entity.NameAr,
                Type = entity.Type,
                IsActive = entity.IsActive
            };
        }

        public static PaymentMethod ToEntity(this PaymentMethodDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new PaymentMethod
            {
                Id = dto.Id,
                NameEn = dto.NameEn,
                NameAr = dto.NameAr,
                Type = dto.Type,
                IsActive = dto.IsActive
            };
        }

        public static void UpdatEentity(this PaymentMethod entity, PaymentMethodDTO dto)
        {

            ArgumentNullException.ThrowIfNull(entity);
            ArgumentNullException.ThrowIfNull(dto);

            entity.NameEn = dto.NameEn;
            entity.NameAr = dto.NameAr;
            entity.Type = dto.Type;
            entity.IsActive = dto.IsActive;

            entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
