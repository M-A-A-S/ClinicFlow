using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    public class LabOrderItem : BaseEntity
    {
        public int LabOrderId { get; set; }
        public int LabTestId { get; set; }
        public LabStatus Status { get; set; } = LabStatus.Pending;
        public LabTest? LabTest { get; set; }
        public LabOrder LabOrder { get; set; }
        public LabResult? Result { get; set; }
    }

}
