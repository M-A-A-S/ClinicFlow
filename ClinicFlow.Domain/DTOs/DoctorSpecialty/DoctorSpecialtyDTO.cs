using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Specialty;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.DoctorSpecialty
{
    public class DoctorSpecialtyDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Doctor),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int DoctorId { get; set; }
        public DoctorDTO? Doctor { get; set; }

        [Display(
            Name = nameof(SharedResource.Specialty),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int SpecialtyId { get; set; }
        public SpecialtyDTO? Specialty { get; set; }
    }
}
