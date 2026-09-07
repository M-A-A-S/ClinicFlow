namespace ClinicFlow.Domain.Entities
{
    public class Diagnosis : BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public bool IsActive { get; set; } = true;

        //public ICollection<VisitDiagnosis> VisitDiagnoses { get; set; }
        //    = new List<VisitDiagnosis>();
    }
}
