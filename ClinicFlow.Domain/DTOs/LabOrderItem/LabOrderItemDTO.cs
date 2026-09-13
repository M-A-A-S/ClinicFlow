using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabOrderItem
{
    public class LabOrderItemDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.LabOrder),
            ResourceType = typeof(SharedResource)
        )]
        public int LabOrderId { get; set; }

        [Display(
            Name = nameof(SharedResource.LabTest),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int LabTestId { get; set; }

        [Display(
            Name = nameof(SharedResource.Status),
            ResourceType = typeof(SharedResource)
        )]
        public LabStatus Status { get; set; } = LabStatus.Pending;

        public LabTestDTO? LabTest { get; set; }
        public LabOrderDTO? LabOrder { get; set; }
        public LabResultDTO? Result { get; set; }
    }
}
