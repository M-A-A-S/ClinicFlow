using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.Prescription;
using ClinicFlow.Domain.DTOs.VisitDiagnosis;
using ClinicFlow.Domain.DTOs.VitalSign;
using ClinicFlow.Domain.DTOs.WaitingQueue;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Visit
{
    public class VisitDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.VisitNumber),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string VisitNumber { get; set; }


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
            Name = nameof(SharedResource.WaitingQueue),
            ResourceType = typeof(SharedResource)
        )]
        public int? WaitingQueueId { get; set; }

        [Display(
            Name = nameof(SharedResource.Appointment),
            ResourceType = typeof(SharedResource)
        )]
        public int? AppointmentId { get; set; }

        [Display(
            Name = nameof(SharedResource.VisitDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime VisitDate { get; set; } = DateTime.UtcNow;

        [Display(
            Name = nameof(SharedResource.Status),
            ResourceType = typeof(SharedResource)
        )]
        public VisitStatus Status { get; set; } = VisitStatus.Open;

        [Display(
            Name = nameof(SharedResource.Complaint),
            ResourceType = typeof(SharedResource)
        )]
        public string? Complaint { get; set; }

        [Display(
            Name = nameof(SharedResource.ClinicalNotes),
            ResourceType = typeof(SharedResource)
        )]
        public string? ClinicalNotes { get; set; }

        [Display(
            Name = nameof(SharedResource.CompletedAt),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? CompletedAt { get; set; }

        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
        public ClinicDTO Clinic { get; set; }
        public WaitingQueueDTO? WaitingQueue { get; set; }
        public AppointmentDTO? Appointment { get; set; }


        public ICollection<VitalSignDTO> VitalSigns { get; set; } = new List<VitalSignDTO>();

        public ICollection<VisitDiagnosisDTO> VisitDiagnoses { get; set; } = new List<VisitDiagnosisDTO>();

        public ICollection<PrescriptionDTO> Prescriptions { get; set; }
            = new List<PrescriptionDTO>();

    }
}
