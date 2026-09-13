namespace ClinicFlow.Domain.Entities
{
    public class LabResult : BaseEntity
    {
        public int LabOrderItemId { get; set; }
        public DateTime ResultDate { get; set; } = DateTime.Now;
        public LabOrderItem OrderItem { get; set; }

        public ICollection<LabResultValue> Values { get; set; }
            = new List<LabResultValue>();
    }

}
