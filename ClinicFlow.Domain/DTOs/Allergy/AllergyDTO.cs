using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicFlow.Domain.Resources.Shared;

namespace ClinicFlow.Domain.DTOs.Allergy
{
    public class AllergyDTO
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
            Name = nameof(SharedResource.DescriptionEn),
            ResourceType = typeof(SharedResource)
        )]
        public string? DescriptionEn { get; set; }

        [Display(
            Name = nameof(SharedResource.DescriptionAr),
            ResourceType = typeof(SharedResource)
        )]
        public string? DescriptionAr { get; set; }

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        public bool IsActive { get; set; } = true;
    }
}
