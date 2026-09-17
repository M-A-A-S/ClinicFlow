using ClinicFlow.Domain.DTOs.LabCategory;
using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.DTOs.LabOrderItem;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class LabOrderExtensions
    {
        public static Expression<Func<LabOrder, LabOrderDTO>>
            ToDTOExpression => Entity => new LabOrderDTO
            {
                Id = Entity.Id,
                VisitId = Entity.VisitId,
                PatientId = Entity.PatientId,
                OrderDate = Entity.OrderDate,

                Items = Entity.Items
                    .Select(x => new LabOrderItemDTO
                    {
                        LabOrderId = x.LabOrderId,
                        LabTestId = x.LabTestId,
                        Status = x.Status,
                    })
                .ToList()

            };


        public static LabOrderDTO ToDTO(this LabOrder Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new LabOrderDTO
            {
                Id = Entity.Id,
                VisitId = Entity.VisitId,
                PatientId = Entity.PatientId,
                OrderDate = Entity.OrderDate,

                Items = Entity.Items
                    .Select(x => new LabOrderItemDTO
                    {
                        LabOrderId = x.LabOrderId,
                        LabTestId = x.LabTestId,
                        Status = x.Status,
                    })
                .ToList()
            };
        }

        public static LabOrder ToEntity(this LabOrderDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new LabOrder
            {
                Id = DTO.Id,
                VisitId = DTO.VisitId,
                PatientId = DTO.PatientId,
                OrderDate = DTO.OrderDate,

                Items = DTO.Items
                    .Select(x => new LabOrderItem
                    {
                        LabOrderId = x.LabOrderId,
                        LabTestId = x.LabTestId,
                        Status = x.Status,
                    })
                .ToList()
            };
        }

        public static void UpdateEntity(this LabOrder Entity, LabOrderDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.VisitId = DTO.VisitId;
            Entity.PatientId = DTO.PatientId;
            Entity.OrderDate = DTO.OrderDate;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
