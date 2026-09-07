using ClinicFlow.Domain.Enums;

namespace ClinicFlow.Domain.Entities
{
    // Walk-in:
    // Patient → Queue → Visit
    public class WaitingQueue : BaseEntity
    {
        public int? AppointmentId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }

        public DateOnly WaitingQueueDate { get; set; }
        public int WaitingQueueNumber { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CalledAt { get; set; }
        public DateTime? ServiceStartAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public QueuePriority Priority { get; set; } = QueuePriority.Normal;
        public QueueStatus Status { get; set; } = QueueStatus.Waiting;

        public Appointment? Appointment { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Clinic Clinic { get; set; }
    }
}
