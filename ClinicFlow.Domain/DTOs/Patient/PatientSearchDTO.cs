using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Patient
{
    public class PatientSearchDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.FullName),
            ResourceType = typeof(SharedResource)
        )]
        public string FullName { get; set; }

        [Display(
            Name = nameof(SharedResource.PhoneNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string? PhoneNumber { get; set; }

    }
}
