using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicFlow.Domain.Entities
{
    public class VitalSign : BaseEntity
    {
        public int VisitId { get; set; }
        public decimal? Temperature { get; set; }
        public int? Pulse { get; set; }
        public int? SystolicBloodPressure { get; set; }
        public int? DiastolicBloodPressure { get; set; }
        public int? RespiratoryRate { get; set; }
        public decimal? OxygenSaturation { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
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

        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

        public Visit Visit { get; set; }
    }
}
