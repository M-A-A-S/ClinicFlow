using ClinicFlow.Domain.DTOs.PatientAllergy;
using ClinicFlow.Domain.DTOs.PatientChronicCondition;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Patient
{
    public class PatientDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.FullName),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string FullName { get; set; }

        [Display(
            Name = nameof(SharedResource.PhoneNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string? PhoneNumber { get; set; }

        [Display(
            Name = nameof(SharedResource.Email),
            ResourceType = typeof(SharedResource)
        )]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(
            Name = nameof(SharedResource.Gender),
            ResourceType = typeof(SharedResource)
        )]
        public Gender Gender { get; set; }

        [Display(
            Name = nameof(SharedResource.NationalId),
            ResourceType = typeof(SharedResource)
        )]
        public string? NationalId { get; set; }

        [Display(
            Name = nameof(SharedResource.Address),
            ResourceType = typeof(SharedResource)
        )]
        public string? Address { get; set; }

        [Display(
            Name = nameof(SharedResource.DateOfBirth),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? DateOfBirth { get; set; }

        [Display(
            Name = nameof(SharedResource.BloodType),
            ResourceType = typeof(SharedResource)
        )]
        public BloodType? BloodType { get; set; }

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        public bool IsActive { get; set; } = true;

        public ICollection<PatientAllergyDTO> PatientAllergies { get; set; }
            = new List<PatientAllergyDTO>();

        public ICollection<PatientChronicConditionDTO> PatientChronicConditions { get; set; }
            = new List<PatientChronicConditionDTO>();

    }
}
