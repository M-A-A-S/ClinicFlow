using ClinicFlow.Domain.DTOs.LabOrderItem;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabOrder
{
    public class LabOrderDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Visit),
            ResourceType = typeof(SharedResource)
        )]
        public int? VisitId { get; set; }

        [Display(
            Name = nameof(SharedResource.Patient),
            ResourceType = typeof(SharedResource)
        )]
        public int? PatientId { get; set; }

        [Display(
            Name = nameof(SharedResource.OrderDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public VisitDTO? Visit { get; set; }
        public PatientDTO? Patient { get; set; }

        public ICollection<LabOrderItemDTO> Items { get; set; }
            = new List<LabOrderItemDTO>();

    }
}
