using ClinicFlow.Domain.DTOs.Medicine;
using ClinicFlow.Domain.DTOs.Prescription;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.PrescriptionItem
{
    public class PrescriptionItemDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Prescription),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int PrescriptionId { get; set; }

        [Display(
            Name = nameof(SharedResource.Medicine),
            ResourceType = typeof(SharedResource)
        )]
        public int? MedicineId { get; set; }

        [Display(
            Name = nameof(SharedResource.MedicineName),
            ResourceType = typeof(SharedResource)
        )]
        public string? MedicineName { get; set; }

        [Display(
            Name = nameof(SharedResource.Dosage),
            ResourceType = typeof(SharedResource)
        )]
        public string? Dosage { get; set; }

        [Display(
            Name = nameof(SharedResource.Frequency),
            ResourceType = typeof(SharedResource)
        )]
        public string? Frequency { get; set; }

        [Display(
            Name = nameof(SharedResource.Duration),
            ResourceType = typeof(SharedResource)
        )]
        public string? Duration { get; set; }

        [Display(
            Name = nameof(SharedResource.Instructions),
            ResourceType = typeof(SharedResource)
        )]
        public string? Instructions { get; set; }

        [Display(
            Name = nameof(SharedResource.Quantity),
            ResourceType = typeof(SharedResource)
        )]
        public int Quantity { get; set; }

        public PrescriptionDTO? Prescription { get; set; }
        public MedicineDTO? Medicine { get; set; }

    }
}
