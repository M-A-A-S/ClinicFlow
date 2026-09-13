namespace ClinicFlow.Domain.Entities
{
    public class LabOrder : BaseEntity
    {
        public int? VisitId { get; set; }
        public Visit? Visit { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ICollection<LabOrderItem> Items { get; set; }
            = new List<LabOrderItem>();
    }

}
