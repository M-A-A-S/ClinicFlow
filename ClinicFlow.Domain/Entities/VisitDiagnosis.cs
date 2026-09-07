namespace ClinicFlow.Domain.Entities
{
    public class VisitDiagnosis : BaseEntity
    {
        public int VisitId { get; set; }     
        public int DiagnosisId { get; set; }   
        public string? Notes { get; set; }

        public Visit Visit { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}
