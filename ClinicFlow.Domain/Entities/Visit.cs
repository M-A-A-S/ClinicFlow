using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    public class Visit : BaseEntity
    {
        public string VisitNumber { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }

        public int? WaitingQueueId { get; set; }
         public int? AppointmentId { get; set; }

        public DateTime VisitDate { get; set; } = DateTime.UtcNow;
        public VisitStatus Status { get; set; } = VisitStatus.Open;

        public string? Complaint { get; set; }
        public string? ClinicalNotes { get; set; }

        public DateTime? CompletedAt { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Clinic Clinic { get; set; }
        public WaitingQueue? WaitingQueue { get; set; }
        public Appointment? Appointment { get; set; }


        public ICollection<VitalSign> VitalSigns { get; set; } = new List<VitalSign>();
        
        public ICollection<VisitDiagnosis> VisitDiagnoses { get; set; } = new List<VisitDiagnosis>();

        public ICollection<Prescription> Prescriptions { get; set; }
            = new List<Prescription>();

    }
}
