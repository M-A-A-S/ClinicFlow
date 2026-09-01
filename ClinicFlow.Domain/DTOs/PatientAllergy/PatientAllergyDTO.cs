using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.PatientAllergy
{
    public class PatientAllergyDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Patient),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int PatientId { get; set; }
  

        [Display(
            Name = nameof(SharedResource.Allergy),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int AllergyId { get; set; }

        [Display(
            Name = nameof(SharedResource.Notes),
            ResourceType = typeof(SharedResource)
        )]
        public string? Notes { get; set; }

        [Display(
            Name = nameof(SharedResource.IdentifiedAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? IdentifiedAt { get; set; } = DateTime.UtcNow;

        public PatientDTO? Patient { get; set; }
        public AllergyDTO? Allergy { get; set; }

    }
}
