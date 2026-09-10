using ClinicFlow.Domain.DTOs.PrescriptionItem;
using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Prescription
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.PrescriptionNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string PrescriptionNumber { get; set; } = string.Empty;

        [Display(
            Name = nameof(SharedResource.Visit),
            ResourceType = typeof(SharedResource)
        )]
        public int VisitId { get; set; }

        [Display(
            Name = nameof(SharedResource.PrescriptionDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime PrescriptionDate { get; set; } = DateTime.Now;

        [Display(
            Name = nameof(SharedResource.Notes),
            ResourceType = typeof(SharedResource)
        )]
        public string? Notes { get; set; }

        public VisitDTO? Visit { get; set; }

        public IList<PrescriptionItemDTO> Items { get; set; }
            = new List<PrescriptionItemDTO>();

    }
}
