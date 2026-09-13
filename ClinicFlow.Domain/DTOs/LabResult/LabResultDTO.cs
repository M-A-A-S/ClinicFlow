using ClinicFlow.Domain.DTOs.LabOrderItem;
using ClinicFlow.Domain.DTOs.LabResultValue;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabResult
{
    public class LabResultDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.LabOrderItem),
            ResourceType = typeof(SharedResource)
        )]
        public int LabOrderItemId { get; set; }

        [Display(
            Name = nameof(SharedResource.ResultDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime ResultDate { get; set; } = DateTime.Now;

        public LabOrderItemDTO? OrderItem { get; set; }
        public ICollection<LabResultValueDTO> Values { get; set; }
            = new List<LabResultValueDTO>();

    }
}
