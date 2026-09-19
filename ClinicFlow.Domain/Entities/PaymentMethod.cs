using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public PaymentMethodType Type { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<InvoicePayment> InvoicePayments { get; set; }
            = new List<InvoicePayment>();
        public ICollection<Bond> Bonds { get; set; } = new List<Bond>();

    }

}
