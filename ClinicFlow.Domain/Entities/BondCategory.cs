using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    public class BondCategory : BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public BondType Type { get; set; } // Specifies if category is for Receipts or Payments
        public bool IsActive { get; set; } = true;
        public ICollection<Bond> Bonds { get; set; } = new List<Bond>();
    }

}
