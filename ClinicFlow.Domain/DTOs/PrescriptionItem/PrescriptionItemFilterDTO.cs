using ClinicFlow.Domain.DTOs.Common;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.PrescriptionItem
{
    public class PrescriptionItemFilterDTO : BaseFilterDTO
    {

        [Display(
            Name = nameof(SharedResource.Prescription),
            ResourceType = typeof(SharedResource)
        )]
        public int? PrescriptionId { get; set; }

        [Display(
            Name = nameof(SharedResource.Medicine),
            ResourceType = typeof(SharedResource)
        )]
        public int? MedicineId { get; set; }

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
