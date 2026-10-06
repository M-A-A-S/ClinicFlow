using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.DTOs.WaitingQueue;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class AppointmentExtensions
    {
        public static Expression<Func<Appointment, AppointmentDTO>>
            ToDTOExpression => static Entity => new AppointmentDTO
            {
                Id = Entity.Id,
                AppointmentNumber = Entity.AppointmentNumber,
                PatientId = Entity.PatientId,
                DoctorId = Entity.DoctorId,
                ClinicId = Entity.ClinicId,
                StartAt = Entity.StartAt,
                EndAt = Entity.EndAt,
                Reason = Entity.Reason,
                Notes = Entity.Notes,
                Status = Entity.Status,

                // =================== Invoice ===================
                InvoiceId = Entity.InvoiceId,
                Invoice = Entity.Invoice == null ? null : new InvoiceDTO
                {
                    Id = Entity.Invoice.Id,
                    InvoiceNumber = Entity.Invoice.InvoiceNumber,
                    Status = Entity.Invoice.Status,
                },

                // =================== Patient ===================
                Patient = Entity.Patient == null
                    ? null
                    : new PatientDTO
                    {
                        Id = Entity.Patient.Id,
                        FullName = Entity.Patient.FullName,
                        PhoneNumber = Entity.Patient.PhoneNumber,
                        Email = Entity.Patient.Email,
                    },

                // =================== Doctor ===================
                Doctor = Entity.Doctor == null
                    ? null
                    : new DoctorDTO
                    {
                        Id = Entity.Doctor.Id,
                        FullName = Entity.Doctor.FullName,
                        PhoneNumber = Entity.Doctor.PhoneNumber,
                        Email = Entity.Doctor.Email,
                    },

                // =================== Clinic ===================
                Clinic = Entity.Clinic == null
                    ? null
                    : new ClinicDTO
                    {
                        Id = Entity.Clinic.Id,
                        NameEn = Entity.Clinic.NameEn,
                        NameAr = Entity.Clinic.NameAr,
                    },

                // =================== Waiting Queue ===================
                WaitingQueueId = Entity.WaitingQueue == null
                    ? null
                    : Entity.WaitingQueue.Id,

                WaitingQueue = Entity.WaitingQueue == null
                    ? null
                    : new WaitingQueueDTO
                    {
                        Id = Entity.WaitingQueue.Id,
                        WaitingQueueNumber = Entity.WaitingQueue.WaitingQueueNumber,
                        WaitingQueueDate = Entity.WaitingQueue.WaitingQueueDate,
                        JoinedAt = Entity.WaitingQueue.JoinedAt,
                        CalledAt = Entity.WaitingQueue.CalledAt,
                        ServiceStartAt = Entity.WaitingQueue.ServiceStartAt,
                        CompletedAt = Entity.WaitingQueue.CompletedAt,
                        Priority = Entity.WaitingQueue.Priority,
                        Status = Entity.WaitingQueue.Status,
                        AppointmentId = Entity.WaitingQueue.AppointmentId,
                        PatientId = Entity.WaitingQueue.PatientId,
                        DoctorId = Entity.WaitingQueue.DoctorId,
                        ClinicId = Entity.WaitingQueue.ClinicId,
                        InvoiceId = Entity.WaitingQueue.InvoiceId,

                        //Visit inside WaitingQueue
                        VisitId = Entity.WaitingQueue.Visit == null
                            ? null
                            : Entity.WaitingQueue.Visit.Id,
                    },

                // =================== Visit ===================
                VisitId = Entity.WaitingQueue == null || Entity.WaitingQueue.Visit == null
                    ? null
                    : Entity.WaitingQueue.Visit.Id,

                Visit = Entity.WaitingQueue == null ||
                Entity.WaitingQueue.Visit == null 
                ? null
                : new VisitDTO
                { 
                    Id = Entity.WaitingQueue.Visit.Id,
                    VisitNumber = Entity.WaitingQueue.Visit.VisitNumber,
                    PatientId = Entity.WaitingQueue.Visit.PatientId,
                    DoctorId = Entity.WaitingQueue.Visit.DoctorId,
                    ClinicId = Entity.WaitingQueue.Visit.ClinicId,
                    WaitingQueueId = Entity.WaitingQueue.Visit.WaitingQueueId,
                    VisitDate = Entity.WaitingQueue.Visit.VisitDate,
                    Status = Entity.WaitingQueue.Visit.Status,
                    Complaint = Entity.WaitingQueue.Visit.Complaint,
                    ClinicalNotes = Entity.WaitingQueue.Visit.ClinicalNotes,
                    CompletedAt = Entity.WaitingQueue.Visit.CompletedAt,
                    InvoiceId = Entity.WaitingQueue.Visit.InvoiceId,
                }



            };


        public static AppointmentDTO ToDTO(this Appointment Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new AppointmentDTO
            {
                Id = Entity.Id,
                AppointmentNumber = Entity.AppointmentNumber,
                PatientId = Entity.PatientId,
                DoctorId = Entity.DoctorId,
                ClinicId = Entity.ClinicId,
                StartAt = Entity.StartAt,
                EndAt = Entity.EndAt,
                Reason = Entity.Reason,
                Notes = Entity.Notes,
                Status = Entity.Status,

                InvoiceId = Entity.InvoiceId,
                Invoice = Entity.Invoice == null ? null : new InvoiceDTO
                {
                    Id = Entity.Invoice.Id,
                    InvoiceNumber = Entity.Invoice.InvoiceNumber,
                    Status = Entity.Invoice.Status,
                },

                Patient = new PatientDTO
                {
                    Id = Entity.Patient.Id,
                    FullName = Entity.Patient.FullName,
                    PhoneNumber = Entity.Patient.PhoneNumber
                },

                Doctor  = new DoctorDTO
                {
                    Id = Entity.Doctor.Id,
                    FullName = Entity.Doctor.FullName,
                    PhoneNumber = Entity.Doctor.PhoneNumber,
                    ConsultationFee = Entity.Doctor.ConsultationFee
                },

                Clinic = new ClinicDTO
                {
                    Id = Entity.Clinic.Id,
                    NameEn = Entity.Clinic.NameEn,
                    NameAr = Entity.Clinic.NameAr,
                },

                // =================== Waiting Queue ===================
                WaitingQueueId = Entity.WaitingQueue == null
                    ? null
                    : Entity.WaitingQueue.Id,

                WaitingQueue = Entity.WaitingQueue == null
                    ? null
                    : new WaitingQueueDTO
                    {
                        Id = Entity.WaitingQueue.Id,
                        WaitingQueueNumber = Entity.WaitingQueue.WaitingQueueNumber,
                        WaitingQueueDate = Entity.WaitingQueue.WaitingQueueDate,
                        JoinedAt = Entity.WaitingQueue.JoinedAt,
                        CalledAt = Entity.WaitingQueue.CalledAt,
                        ServiceStartAt = Entity.WaitingQueue.ServiceStartAt,
                        CompletedAt = Entity.WaitingQueue.CompletedAt,
                        Priority = Entity.WaitingQueue.Priority,
                        Status = Entity.WaitingQueue.Status,
                        AppointmentId = Entity.WaitingQueue.AppointmentId,
                        PatientId = Entity.WaitingQueue.PatientId,
                        DoctorId = Entity.WaitingQueue.DoctorId,
                        ClinicId = Entity.WaitingQueue.ClinicId,
                        InvoiceId = Entity.WaitingQueue.InvoiceId,

                        //Visit inside WaitingQueue
                        VisitId = Entity.WaitingQueue.Visit == null
                            ? null
                            : Entity.WaitingQueue.Visit.Id,
                    },

                // =================== Visit ===================
                VisitId = Entity.WaitingQueue == null || Entity.WaitingQueue.Visit == null
                    ? null
                    : Entity.WaitingQueue.Visit.Id,

                Visit = Entity.WaitingQueue == null ||
                Entity.WaitingQueue.Visit == null
                ? null
                : new VisitDTO
                {
                    Id = Entity.WaitingQueue.Visit.Id,
                    VisitNumber = Entity.WaitingQueue.Visit.VisitNumber,
                    PatientId = Entity.WaitingQueue.Visit.PatientId,
                    DoctorId = Entity.WaitingQueue.Visit.DoctorId,
                    ClinicId = Entity.WaitingQueue.Visit.ClinicId,
                    WaitingQueueId = Entity.WaitingQueue.Visit.WaitingQueueId,
                    VisitDate = Entity.WaitingQueue.Visit.VisitDate,
                    Status = Entity.WaitingQueue.Visit.Status,
                    Complaint = Entity.WaitingQueue.Visit.Complaint,
                    ClinicalNotes = Entity.WaitingQueue.Visit.ClinicalNotes,
                    CompletedAt = Entity.WaitingQueue.Visit.CompletedAt,
                    InvoiceId = Entity.WaitingQueue.Visit.InvoiceId,
                }

            };
        }

        public static Appointment ToEntity(this AppointmentDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Appointment
            {
                Id = DTO.Id,
                AppointmentNumber = DTO.AppointmentNumber,
                PatientId = DTO.PatientId,
                DoctorId = DTO.DoctorId,
                ClinicId = DTO.ClinicId,
                StartAt = DTO.StartAt,
                EndAt = DTO.EndAt,
                Reason = DTO.Reason,
                Notes = DTO.Notes,
                Status = DTO.Status
            };
        }

        public static void UpdateEntity(this Appointment Entity, AppointmentDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.AppointmentNumber = DTO.AppointmentNumber;
            Entity.PatientId = DTO.PatientId;
            Entity.DoctorId = DTO.DoctorId;
            Entity.ClinicId = DTO.ClinicId;
            Entity.StartAt = DTO.StartAt;
            Entity.EndAt = DTO.EndAt;
            Entity.Reason = DTO.Reason;
            Entity.Notes = DTO.Notes;
            Entity.Status = DTO.Status;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
