using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClinicFlow.Domain.DTOs.Prescription;
using ClinicFlow.Domain.DTOs.PrescriptionItem;

namespace ClinicFlow.Domain.Extensions
{
    public static class VisitExtensions
    {
        public static Expression<Func<Visit, VisitDTO>>
            ToDTOExpression => Entity => new VisitDTO
            {
                Id = Entity.Id,
                VisitNumber = Entity.VisitNumber,
                PatientId = Entity.PatientId,
                DoctorId = Entity.DoctorId,
                ClinicId = Entity.ClinicId,
                WaitingQueueId = Entity.WaitingQueueId,
                AppointmentId = Entity.AppointmentId,
                VisitDate = Entity.VisitDate,
                Status = Entity.Status,
                Complaint = Entity.Complaint,
                ClinicalNotes = Entity.ClinicalNotes,
                CompletedAt = Entity.CompletedAt,

                Patient = Entity.Patient == null
                    ? null
                    : new PatientDTO
                    {
                        Id = Entity.Patient.Id,
                        FullName = Entity.Patient.FullName,
                        PhoneNumber = Entity.Patient.PhoneNumber,
                        Email = Entity.Patient.Email,
                    },

                Doctor = Entity.Doctor == null
                    ? null
                    : new DoctorDTO
                    {
                        Id = Entity.Doctor.Id,
                        FullName = Entity.Doctor.FullName,
                        PhoneNumber = Entity.Doctor.PhoneNumber,
                        Email = Entity.Doctor.Email,
                    },

                Clinic = Entity.Clinic == null
                    ? null
                    : new ClinicDTO
                    {
                        Id = Entity.Clinic.Id,
                        NameEn = Entity.Clinic.NameEn,
                        NameAr = Entity.Clinic.NameAr,
                    }

            };


        public static VisitDTO ToDTO(this Visit Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new VisitDTO
            {
                Id = Entity.Id,
                VisitNumber = Entity.VisitNumber,
                PatientId = Entity.PatientId,
                DoctorId = Entity.DoctorId,
                ClinicId = Entity.ClinicId,
                WaitingQueueId = Entity.WaitingQueueId,
                AppointmentId = Entity.AppointmentId,
                VisitDate = Entity.VisitDate,
                Status = Entity.Status,
                Complaint = Entity.Complaint,
                ClinicalNotes = Entity.ClinicalNotes,
                CompletedAt = Entity.CompletedAt,

                Patient = new PatientDTO
                {
                    Id = Entity.Patient.Id,
                    FullName = Entity.Patient.FullName,
                    PhoneNumber = Entity.Patient.PhoneNumber
                },

                Doctor = new DoctorDTO
                {
                    Id = Entity.Doctor.Id,
                    FullName = Entity.Doctor.FullName,
                    PhoneNumber = Entity.Doctor.PhoneNumber
                },

                Clinic = new ClinicDTO
                {
                    Id = Entity.Clinic.Id,
                    NameEn = Entity.Clinic.NameEn,
                    NameAr = Entity.Clinic.NameAr,
                },

                Prescription = Entity.Prescription == null ? null : new PrescriptionDTO
                {
                    Id = Entity.Prescription.Id,
                    PrescriptionNumber = Entity.Prescription.PrescriptionNumber,
                    PrescriptionDate = Entity.Prescription.PrescriptionDate,
                    Notes = Entity.Prescription.Notes,

                    Items = Entity.Prescription.Items?
                        .Select(x => new PrescriptionItemDTO
                        {
                            Id = x.Id,
                            MedicineId = x.MedicineId,
                            MedicineName = x.MedicineName,
                            Dosage = x.Dosage,
                            Frequency = x.Frequency,
                            Duration = x.Duration,
                            Quantity = x.Quantity,
                            Instructions = x.Instructions
                        }).ToList()
                }

            };
        }

        public static Visit ToEntity(this VisitDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Visit
            {
                Id = DTO.Id,
                VisitNumber = DTO.VisitNumber,
                PatientId = DTO.PatientId,
                DoctorId = DTO.DoctorId,
                ClinicId = DTO.ClinicId,
                WaitingQueueId = DTO.WaitingQueueId,
                AppointmentId = DTO.AppointmentId,
                VisitDate = DTO.VisitDate,
                Status = DTO.Status,
                Complaint = DTO.Complaint,
                ClinicalNotes = DTO.ClinicalNotes,
                CompletedAt = DTO.CompletedAt,

                // ======================== Vital Sign ========================

                VitalSign = DTO.VitalSign == null ? null : new VitalSign
                {
                    Id = DTO.VitalSign.Id,
                    VisitId = DTO.VitalSign.VisitId,
                    Temperature = DTO.VitalSign.Temperature,
                    Pulse = DTO.VitalSign.Pulse,
                    SystolicBloodPressure = DTO.VitalSign.SystolicBloodPressure,
                    DiastolicBloodPressure = DTO.VitalSign.DiastolicBloodPressure,
                    RespiratoryRate = DTO.VitalSign.RespiratoryRate,
                    OxygenSaturation = DTO.VitalSign.OxygenSaturation,
                    Weight = DTO.VitalSign.Weight,
                    Height = DTO.VitalSign.Height,
                    RecordedAt = DTO.VitalSign.RecordedAt
                },

                // ======================== Diagnoses ========================
                VisitDiagnoses = DTO.VisitDiagnoses?
                    .Select(x => new VisitDiagnosis
                    {
                        Id = x.Id,
                        VisitId = x.VisitId,
                        DiagnosisId = x.DiagnosisId,
                        Notes = x.Notes
                    })
                    .ToList()
                    ?? new List<VisitDiagnosis>(),

                // ======================== Prescription ========================
                Prescription = DTO.Prescription == null ? null : new Prescription
                {
                    Id = DTO.Prescription.Id,
                    PrescriptionDate = DTO.Prescription.PrescriptionDate,
                    PrescriptionNumber = DTO.Prescription.PrescriptionNumber,
                    Notes = DTO.Prescription.Notes,
                    Items = DTO.Prescription.Items?
                        .Select(x => new PrescriptionItem
                        {
                            Id = x.Id,
                            MedicineId = x.MedicineId,
                            MedicineName = x.MedicineName,
                            Quantity = x.Quantity,
                            Dosage = x.Dosage,
                            Frequency = x.Frequency,
                            Duration = x.Duration
                        }).ToList()
                }

            };
        }

        public static void UpdateEntity(this Visit Entity, VisitDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.VisitNumber = DTO.VisitNumber;
            Entity.PatientId = DTO.PatientId;
            Entity.DoctorId = DTO.DoctorId;
            Entity.ClinicId = DTO.ClinicId;
            Entity.WaitingQueueId = DTO.WaitingQueueId;
            Entity.AppointmentId = DTO.AppointmentId;
            Entity.VisitDate = DTO.VisitDate;
            Entity.Status = DTO.Status;
            Entity.Complaint = DTO.Complaint;
            Entity.ClinicalNotes = DTO.ClinicalNotes;
            Entity.CompletedAt = DTO.CompletedAt;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
