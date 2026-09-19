using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    // Standalone Payment or Receipt Voucher (NOT bound to an Invoice)
    public class Bond : BaseEntity
    {
        public string BondNumber { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public BondType Type { get; set; } // Receipt (Money In) or Payment (Money Out)
        public PartyType Party { get; set; } = PartyType.General;
        public int? PartyId { get; set; } // PatientId or SupplierId if Party != General
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public string? Notes { get; set; }
        public string? ReferenceNumber { get; set; } // e.g., Bank Transfer Reference

        public virtual BondCategory Category { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
    }

}
