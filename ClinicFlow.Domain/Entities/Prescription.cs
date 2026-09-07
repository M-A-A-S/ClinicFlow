namespace ClinicFlow.Domain.Entities
{
    public class Prescription : BaseEntity
    {
        public string PrescriptionNumber { get; set; }
        public int VisitId { get; set; }
        
        public DateTime PrescriptionDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }

        public Visit Visit { get; set; }

        public ICollection<PrescriptionItem> Items { get; set; }
            = new List<PrescriptionItem>();

    }
}
