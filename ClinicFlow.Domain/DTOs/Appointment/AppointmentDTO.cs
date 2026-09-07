using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.DTOs.WaitingQueue;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Appointment
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.AppointmentNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string AppointmentNumber { get; set; } = string.Empty;

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
            Name = nameof(SharedResource.Clinic),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int ClinicId { get; set; }

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
            Name = nameof(SharedResource.StartAt),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public DateTime StartAt { get; set; } = DateTime.Now;

        [Display(
            Name = nameof(SharedResource.EndAt),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public DateTime EndAt { get; set; } = DateTime.Now.AddMinutes(30);

        [Display(
            Name = nameof(SharedResource.Status),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

        [Display(
            Name = nameof(SharedResource.Reason),
            ResourceType = typeof(SharedResource)
        )]
        public string? Reason { get; set; }

        [Display(
            Name = nameof(SharedResource.Notes),
            ResourceType = typeof(SharedResource)
        )]

        public string? Notes { get; set; }

        public PatientDTO? Patient { get; set; }
        public ClinicDTO? Clinic { get; set; }
        public DoctorDTO? Doctor { get; set; }

        public WaitingQueueDTO? WaitingQueue { get; set; }
        public VisitDTO? Visit { get; set; }

    }
}
