namespace ClinicFlow.Domain.Entities
{
    public class PrescriptionItem : BaseEntity
    {
        public int PrescriptionId { get; set; }
        public int? MedicineId { get; set; }  
        public string? MedicineName { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Instructions { get; set; }
        public int Quantity { get; set; }

        public Prescription Prescription { get; set; }
        public Medicine? Medicine { get; set; }

    }
}
