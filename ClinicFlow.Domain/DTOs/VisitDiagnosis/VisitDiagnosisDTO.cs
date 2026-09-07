using ClinicFlow.Domain.DTOs.Diagnosis;
using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.VisitDiagnosis
{
    public class VisitDiagnosisDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Visit),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int VisitId { get; set; }

        [Display(
            Name = nameof(SharedResource.Diagnosis),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int DiagnosisId { get; set; }

        [Display(
            Name = nameof(SharedResource.Notes),
            ResourceType = typeof(SharedResource)
        )]
        public string? Notes { get; set; }

        public VisitDTO? Visit { get; set; }
        public DiagnosisDTO? Diagnosis { get; set; }

    }
}
