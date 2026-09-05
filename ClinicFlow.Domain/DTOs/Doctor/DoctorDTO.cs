using ClinicFlow.Domain.DTOs.DoctorSpecialty;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Doctor
{
    public class DoctorDTO
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
        public string? Email { get; set; }

        [Display(
            Name = nameof(SharedResource.ConsultationFee),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public decimal ConsultationFee { get; set; }

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        public bool IsActive { get; set; } = true;

        public ICollection<DoctorSpecialtyDTO> DoctorSpecialties { get; set; }
            = new List<DoctorSpecialtyDTO>();

    }
}
