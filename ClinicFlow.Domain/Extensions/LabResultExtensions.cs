using ClinicFlow.Domain.DTOs.LabOrderItem;
using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.DTOs.LabResultValue;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.LabTestParameter;
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
    public static class LabResultExtensions
    {
        public static Expression<Func<LabResult, LabResultDTO>>
            ToDTOExpression => Entity => new LabResultDTO
            {
                Id = Entity.Id,
                LabOrderItemId = Entity.LabOrderItemId,
                ResultDate = Entity.ResultDate,

                OrderItem = Entity.OrderItem == null ? null : new LabOrderItemDTO()
                {
                    Id = Entity.OrderItem.Id,
                    LabTestId = Entity.OrderItem.LabTestId,
                    Status = Entity.OrderItem.Status,

                    LabTest = Entity.OrderItem.LabTest == null ? null : new LabTestDTO
                    {
                        Id = Entity.OrderItem.LabTest.Id,
                        NameEn = Entity.OrderItem.LabTest.NameEn,
                        NameAr = Entity.OrderItem.LabTest.NameAr,
                        Price = Entity.OrderItem.LabTest.Price,
                    }
                },

                Values = Entity.Values
                    .Select(x => new LabResultValueDTO
                    {
                        LabResultId = x.LabResultId,
                        ParameterId = x.ParameterId,
                        Value = x.Value,
                        NumericValue = x.NumericValue,
                        Unit = x.Unit,
                        NormalRange = x.NormalRange,
                        Flag = x.Flag,

                        Parameter = x.Parameter == null ? null : new LabTestParameterDTO
                        {
                            Id = x.Parameter.Id,
                            LabTestId = x.Parameter.LabTestId,
                            NameEn = x.Parameter.NameEn,
                            NameAr = x.Parameter.NameAr,
                            Unit = x.Parameter.Unit,
                            NormalRange = x.Parameter.NormalRange,
                            DisplayOrder = x.Parameter.DisplayOrder,
                        }
                    })
                .ToList()

            };


        public static LabResultDTO ToDTO(this LabResult Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new LabResultDTO
            {
                Id = Entity.Id,
                LabOrderItemId = Entity.LabOrderItemId,
                ResultDate = Entity.ResultDate,

                OrderItem = Entity.OrderItem == null ? null : new LabOrderItemDTO()
                {
                    Id = Entity.OrderItem.Id,
                    LabTestId = Entity.OrderItem.LabTestId,
                    Status = Entity.OrderItem.Status,

                    LabTest = Entity.OrderItem.LabTest == null ? null : new LabTestDTO
                    {
                        Id = Entity.OrderItem.LabTest.Id,
                        NameEn = Entity.OrderItem.LabTest.NameEn,
                        NameAr = Entity.OrderItem.LabTest.NameAr,
                        Price = Entity.OrderItem.LabTest.Price,
                    }
                },

                Values = Entity.Values
                    .Select(x => new LabResultValueDTO
                    {
                        LabResultId = x.LabResultId,
                        ParameterId = x.ParameterId,
                        Value = x.Value,
                        NumericValue = x.NumericValue,
                        Unit = x.Unit,
                        NormalRange = x.NormalRange,
                        Flag = x.Flag,

                        Parameter = x.Parameter == null ? null : new LabTestParameterDTO
                        {
                            Id = x.Parameter.Id,
                            LabTestId = x.Parameter.LabTestId,
                            NameEn = x.Parameter.NameEn,
                            NameAr = x.Parameter.NameAr,
                            Unit = x.Parameter.Unit,
                            NormalRange = x.Parameter.NormalRange,
                            DisplayOrder = x.Parameter.DisplayOrder,
                        }
                    })
                .ToList()
            };
        }

        public static LabResult ToEntity(this LabResultDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new LabResult
            {
                Id = DTO.Id,
                LabOrderItemId = DTO.LabOrderItemId,
                ResultDate = DTO.ResultDate,

                Values = DTO.Values
                    .Select(x => new LabResultValue
                    {
                        LabResultId = x.LabResultId,
                        ParameterId = x.ParameterId,
                        Value = x.Value,
                        NumericValue = x.NumericValue,
                        Unit = x.Unit,
                        NormalRange = x.NormalRange,
                        Flag = x.Flag,
                    })
                .ToList()
            };
        }

        public static void UpdateEntity(this LabResult Entity, LabResultDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.LabOrderItemId = DTO.LabOrderItemId;
            Entity.ResultDate = DTO.ResultDate;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
