using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabTestParameter
{
    public class LabTestParameterDTO
    {
        public int Id { get; set; }


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
            Name = nameof(SharedResource.NameEn),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public required string NameEn { get; set; }

        [Display(
            Name = nameof(SharedResource.NameAr),
            ResourceType = typeof(SharedResource)
        )]
        public string? NameAr { get; set; }


        [Display(
            Name = nameof(SharedResource.Unit),
            ResourceType = typeof(SharedResource)
        )]
        // Example: g/dL, mg/dL, %, etc.
        public string? Unit { get; set; }

        [Display(
            Name = nameof(SharedResource.NormalRange),
            ResourceType = typeof(SharedResource)
        )]
        // Example: "12 - 16"
        public string? NormalRange { get; set; }

        [Display(
            Name = nameof(SharedResource.DisplayOrder),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        // Controls the order in the report/UI
        public int DisplayOrder { get; set; }

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public bool IsActive { get; set; } = true;
        public LabTestDTO? LabTest { get; set; }

    }
}
