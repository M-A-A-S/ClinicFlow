using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    public class LabResultValue : BaseEntity
    {
        public int LabResultId { get; set; }
        public int ParameterId { get; set; }

        // Value entered/displayed by the lab
        public string? Value { get; set; }
        // Used when the result is numeric
        public decimal? NumericValue { get; set; }

        // Snapshot at time result was produced
        public string? Unit { get; set; }
        public string? NormalRange { get; set; }

        public LabResultFlag Flag { get; set; } = LabResultFlag.None;

        public LabResult LabResult { get; set; }
        public LabTestParameter Parameter { get; set; }
    }

}
