using ClinicFlow.Domain.DTOs.ChronicCondition;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.PatientChronicCondition
{
    public class PatientChronicConditionDTO
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
            Name = nameof(SharedResource.ChronicCondition),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int ChronicConditionId { get; set; }

        [Display(
            Name = nameof(SharedResource.Notes),
            ResourceType = typeof(SharedResource)
        )]

        public string? Notes { get; set; }

        [Display(
            Name = nameof(SharedResource.DiagnosedAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? DiagnosedAt { get; set; } = DateTime.UtcNow;

        public PatientDTO? Patient { get; set; }
        public ChronicConditionDTO? ChronicCondition { get; set; }

    }
}
