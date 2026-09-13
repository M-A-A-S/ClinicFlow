namespace ClinicFlow.Domain.Entities
{
    public class LabTest : BaseEntity
    {
        //public required string Code { get; set; }
        public int? CategoryId { get; set; }
        public required string NameEn { get; set; }
        public string? NameAr { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;

        public LabCategory? Category { get; set; } 
        public ICollection<LabTestParameter> Parameters { get; set; }
            = new List<LabTestParameter>();
    }

}
