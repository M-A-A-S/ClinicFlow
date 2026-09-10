using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.VitalSign
{
    public class VitalSignDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Visit),
            ResourceType = typeof(SharedResource)
        )]
        //[Required(
        //    ErrorMessageResourceName = nameof(SharedResource.Required),
        //    ErrorMessageResourceType = typeof(SharedResource)
        //)]
        public int VisitId { get; set; }

        [Display(
            Name = nameof(SharedResource.Temperature),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? Temperature { get; set; }

        [Display(
            Name = nameof(SharedResource.Pulse),
            ResourceType = typeof(SharedResource)
        )]
        public int? Pulse { get; set; }

        [Display(
            Name = nameof(SharedResource.SystolicBloodPressure),
            ResourceType = typeof(SharedResource)
        )]
        public int? SystolicBloodPressure { get; set; }

        [Display(
            Name = nameof(SharedResource.DiastolicBloodPressure),
            ResourceType = typeof(SharedResource)
        )]
        public int? DiastolicBloodPressure { get; set; }

        [Display(
            Name = nameof(SharedResource.RespiratoryRate),
            ResourceType = typeof(SharedResource)
        )]
        public int? RespiratoryRate { get; set; }

        [Display(
            Name = nameof(SharedResource.OxygenSaturation),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? OxygenSaturation { get; set; }

        [Display(
            Name = nameof(SharedResource.Weight),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? Weight { get; set; }

        [Display(
            Name = nameof(SharedResource.Height),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? Height { get; set; }

        [Display(
            Name = nameof(SharedResource.BMI),
            ResourceType = typeof(SharedResource)
        )]
        [NotMapped]
        public decimal? BMI
        {
            get
            {
                if (!Weight.HasValue ||
                    !Height.HasValue ||
                    Height.Value <= 0)
                {
                    return null;
                }

                var heightMeters = Height.Value / 100m;

                return Math.Round(
                    Weight.Value /
                    (heightMeters * heightMeters), 2);
            }
        }

        [Display(
            Name = nameof(SharedResource.RecordedAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

        public VisitDTO? Visit { get; set; }

    }
}
