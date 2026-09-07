namespace ClinicFlow.Domain.Entities
{
    public class ClinicDoctor : BaseEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
