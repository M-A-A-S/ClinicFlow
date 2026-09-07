using ClinicFlow.Domain.DTOs.PrescriptionItem;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Medicine
{
    public class MedicineDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.NameEn),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string NameEn { get; set; }

        [Display(
            Name = nameof(SharedResource.NameAr),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string NameAr { get; set; }


        [Display(
            Name = nameof(SharedResource.GenericNameEn),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string GenericNameEn { get; set; }

        [Display(
            Name = nameof(SharedResource.GenericNameAr),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string GenericNameAr { get; set; }

        [Display(
            Name = nameof(SharedResource.Strength),
            ResourceType = typeof(SharedResource)
        )]
        public string? Strength { get; set; }

        [Display(
            Name = nameof(SharedResource.DosageForm),
            ResourceType = typeof(SharedResource)
        )]
        public string? DosageForm { get; set; } // e.g., Tablet, Capsule, Syrup

        [Display(
            Name = nameof(SharedResource.Route),
            ResourceType = typeof(SharedResource)
        )]
        public string? Route { get; set; } // e.g., Oral, IV, Topical

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        public bool IsActive { get; set; } = true;

        public ICollection<PrescriptionItemDTO> PrescriptionItems { get; set; }
            = new List<PrescriptionItemDTO>();

    }
}
