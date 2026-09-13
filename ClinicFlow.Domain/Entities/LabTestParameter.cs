namespace ClinicFlow.Domain.Entities
{
    public class LabTestParameter : BaseEntity
    {
        public int LabTestId { get; set; }
        public required string NameEn { get; set; }
        public string? NameAr { get; set; }
        // Example: g/dL, mg/dL, %, etc.
        public string? Unit { get; set; }
        // Example: "12 - 16"
        public string? NormalRange { get; set; }
        // Controls the order in the report/UI
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public LabTest LabTest { get; set; }
    }

}
