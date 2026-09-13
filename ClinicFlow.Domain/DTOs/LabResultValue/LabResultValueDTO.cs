using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.DTOs.LabTestParameter;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabResultValue
{
    public class LabResultValueDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.LabTest),
            ResourceType = typeof(SharedResource)
        )]
        public int LabResultId { get; set; }

        [Display(
            Name = nameof(SharedResource.Parameter),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int ParameterId { get; set; }

        [Display(
            Name = nameof(SharedResource.Value),
            ResourceType = typeof(SharedResource)
        )]
        // Value entered/displayed by the lab
        public string? Value { get; set; }

        [Display(
            Name = nameof(SharedResource.NumericValue),
            ResourceType = typeof(SharedResource)
        )]
        // Used when the result is numeric
        public decimal? NumericValue { get; set; }

        [Display(
            Name = nameof(SharedResource.Unit),
            ResourceType = typeof(SharedResource)
        )]
        // Snapshot at time result was produced
        public string? Unit { get; set; }

        [Display(
            Name = nameof(SharedResource.NormalRange),
            ResourceType = typeof(SharedResource)
        )]
        // Snapshot at time result was produced
        public string? NormalRange { get; set; }

        [Display(
            Name = nameof(SharedResource.Flag),
            ResourceType = typeof(SharedResource)
        )]
        public LabResultFlag Flag { get; set; } = LabResultFlag.None;

        public LabResultDTO? LabResult { get; set; }
        public LabTestParameterDTO? Parameter { get; set; }

    }
}
