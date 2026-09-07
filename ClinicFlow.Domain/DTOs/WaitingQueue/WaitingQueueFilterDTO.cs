using ClinicFlow.Domain.DTOs.Common;
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
    public class WaitingQueueFilterDTO : BaseFilterDTO
    {

        [Display(
            Name = nameof(SharedResource.Appointment),
            ResourceType = typeof(SharedResource)
        )]
        public string? AppointmentId { get; set; }

        [Display(
            Name = nameof(SharedResource.Patient),
            ResourceType = typeof(SharedResource)
        )]
        public int? PatientId { get; set; }

        [Display(
            Name = nameof(SharedResource.Clinic),
            ResourceType = typeof(SharedResource)
        )]
        public int? ClinicId { get; set; }

        [Display(
            Name = nameof(SharedResource.Doctor),
            ResourceType = typeof(SharedResource)
        )]
        public int? DoctorId { get; set; }

        [Display(
            Name = nameof(SharedResource.FromDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? FromDate { get; set; }

        [Display(
            Name = nameof(SharedResource.ToDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? ToDate { get; set; }

        [Display(
            Name = nameof(SharedResource.QueueNumber),
            ResourceType = typeof(SharedResource)
        )]
        public int? WaitingQueueNumber { get; set; }

        [Display(
            Name = nameof(SharedResource.Priority),
            ResourceType = typeof(SharedResource)
        )]
        public QueuePriority? Priority { get; set; }

        [Display(
            Name = nameof(SharedResource.Status),
            ResourceType = typeof(SharedResource)
        )]
        public QueueStatus? Status { get; set; }

    }
}
