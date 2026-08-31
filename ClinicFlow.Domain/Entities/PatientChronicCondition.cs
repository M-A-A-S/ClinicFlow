using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{
    public class PatientChronicCondition : BaseEntity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int ChronicConditionId { get; set; }
        public ChronicCondition ChronicCondition { get; set; }
        public string? Notes { get; set; }
        public DateTime? DiagnosedAt { get; set; } = DateTime.UtcNow;
    }

}
