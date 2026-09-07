using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.WaitingQueue
{
    public class WaitingQueueDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Appointment),
            ResourceType = typeof(SharedResource)
        )]
        public int? AppointmentId { get; set; }

        [Display(
            Name = nameof(SharedResource.Patient),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int PatientId { get; set; }

        [Display(
            Name = nameof(SharedResource.Doctor),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int DoctorId { get; set; }

        [Display(
            Name = nameof(SharedResource.Clinic),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int ClinicId { get; set; }

        [Display(
            Name = nameof(SharedResource.QueueDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateOnly WaitingQueueDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        [Display(
            Name = nameof(SharedResource.QueueNumber),
            ResourceType = typeof(SharedResource)
        )]
        public int WaitingQueueNumber { get; set; }


        [Display(
            Name = nameof(SharedResource.JoinedAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        [Display(
            Name = nameof(SharedResource.CalledAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? CalledAt { get; set; }

        [Display(
            Name = nameof(SharedResource.ServiceStartAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? ServiceStartAt { get; set; }

        [Display(
            Name = nameof(SharedResource.CompletedAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? CompletedAt { get; set; }

        [Display(
            Name = nameof(SharedResource.Priority),
            ResourceType = typeof(SharedResource)
        )]
        public QueuePriority Priority { get; set; } = QueuePriority.Normal;

        [Display(
            Name = nameof(SharedResource.Status),
            ResourceType = typeof(SharedResource)
        )]
        public QueueStatus Status { get; set; } = QueueStatus.Waiting;

        public AppointmentDTO? Appointment { get; set; }
        public PatientDTO? Patient { get; set; }
        public DoctorDTO? Doctor { get; set; }
        public ClinicDTO? Clinic { get; set; }

    }
}
