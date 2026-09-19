using ClinicFlow.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Entities
{
    public class InvoicePayment : BaseEntity
    {
        [Required]
        public string ReceiptNumber { get; set; } = string.Empty;
        public int InvoiceId { get; set; }

        // Receipt = money received against invoice | Payment = refund to patient
        public BondType Type { get; set; } = BondType.Receipt; // Receipt (In) or Refund (Out)
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
        public string? ReferenceNumber { get; set; } // e.g., Bank Transfer Reference

        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual Invoice Invoice { get; set; } = null!;
    }

}
