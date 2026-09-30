using ClinicFlow.Domain.DTOs.Bond;
using ClinicFlow.Domain.DTOs.BondCategory;
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
    public static class BondExtensions
    {
        public static Expression<Func<Bond, BondDTO>>
            ToDTOExpression => entity => new BondDTO
            {
                Id = entity.Id,
                BondNumber = entity.BondNumber,
                IssueDate = entity.IssueDate,
                Type = entity.Type,
                Party = entity.Party,
                PartyId = entity.PartyId,
                CategoryId = entity.CategoryId,
                Amount = entity.Amount,
                PaymentMethodId = entity.PaymentMethodId,
                Notes = entity.Notes,
                ReferenceNumber = entity.ReferenceNumber,

                Category = entity == null ? null : new BondCategoryDTO
                {
                    Id = entity.Category.Id,
                    NameEn = entity.Category.NameEn,
                    NameAr = entity.Category.NameAr,
                    Type = entity.Type,
                },

                PaymentMethod = entity == null ? null : new PaymentMethodDTO
                {
                    Id = entity.PaymentMethod.Id,
                    NameEn = entity.PaymentMethod.NameEn,
                    NameAr = entity.PaymentMethod.NameAr
                }
            };


        public static BondDTO ToDTO(this Bond entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new BondDTO
            {
                Id = entity.Id,
                BondNumber = entity.BondNumber,
                IssueDate = entity.IssueDate,
                Type = entity.Type,
                Party = entity.Party,
                PartyId = entity.PartyId,
                CategoryId = entity.CategoryId,
                Amount = entity.Amount,
                PaymentMethodId = entity.PaymentMethodId,
                Notes = entity.Notes,
                ReferenceNumber = entity.ReferenceNumber,

                Category = entity == null ? null : new BondCategoryDTO
                {
                    Id = entity.Category.Id,
                    NameEn = entity.Category.NameEn,
                    NameAr = entity.Category.NameAr,
                    Type = entity.Type,
                },

                PaymentMethod = entity == null ? null : new PaymentMethodDTO
                {
                    Id = entity.PaymentMethod.Id,
                    NameEn = entity.PaymentMethod.NameEn,
                    NameAr = entity.PaymentMethod.NameAr
                }
            };
        }

        public static Bond ToEntity(this BondDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Bond
            {
                Id = dto.Id,
                BondNumber = dto.BondNumber,
                IssueDate = dto.IssueDate,
                Type = dto.Type,
                Party = dto.Party,
                PartyId = dto.PartyId,
                CategoryId = dto.CategoryId,
                Amount = dto.Amount,
                PaymentMethodId = dto.PaymentMethodId,
                Notes = dto.Notes,
                ReferenceNumber = dto.ReferenceNumber,
            };
        }

        public static void UpdateEntity(this Bond entity, BondDTO dto)
        {

            ArgumentNullException.ThrowIfNull(entity);
            ArgumentNullException.ThrowIfNull(dto);

            entity.IssueDate = dto.IssueDate;
            entity.Type = dto.Type;
            entity.Party = dto.Party;
            entity.PartyId = dto.PartyId;
            entity.CategoryId = dto.CategoryId;
            entity.Amount = dto.Amount;
            entity.PaymentMethodId = dto.PaymentMethodId;
            entity.Notes = dto.Notes;
            entity.ReferenceNumber = dto.ReferenceNumber;

            entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
