using ClinicFlow.Domain.DTOs.Common;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.VisitDiagnosis
{
    public class VisitDiagnosisFilterDTO : BaseFilterDTO
    {

        [Display(
            Name = nameof(SharedResource.Visit),
            ResourceType = typeof(SharedResource)
        )]
        public int? VisitId { get; set; }

        [Display(
            Name = nameof(SharedResource.Diagnosis),
            ResourceType = typeof(SharedResource)
        )]
        public int? DiagnosisId { get; set; }

        [Display(
            Name = nameof(SharedResource.Patient),
            ResourceType = typeof(SharedResource)
        )]
        public int? PatientId { get; set; }

        [Display(
            Name = nameof(SharedResource.Doctor),
            ResourceType = typeof(SharedResource)
        )]
        public int? DoctorId { get; set; }

    }
}
