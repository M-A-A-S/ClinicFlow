using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    public class InvoiceItem : BaseEntity
    {
        public int InvoiceId { get; set; }
        public InvoiceItemType ItemType { get; set; }
        // Visit, LabOrderItem, PrescriptionItem
        public int ReferenceId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string? Description { get; set; }

        public Invoice Invoice { get; set; }

    }

}
