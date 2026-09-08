using ClinicFlow.Domain.DTOs.WaitingQueue;
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

namespace ClinicFlow.Domain.Extensions
{
    public static class WaitingQueueExtensions
    {
        public static Expression<Func<WaitingQueue, WaitingQueueDTO>>
            ToDTOExpression => Entity => new WaitingQueueDTO
            {
                Id = Entity.Id,
                PatientId = Entity.PatientId,
                DoctorId = Entity.DoctorId,
                ClinicId = Entity.ClinicId,
                WaitingQueueNumber = Entity.WaitingQueueNumber,
                WaitingQueueDate = Entity.WaitingQueueDate,
                JoinedAt = Entity.JoinedAt,
                CalledAt = Entity.CalledAt,
                ServiceStartAt = Entity.ServiceStartAt,
                CompletedAt = Entity.CompletedAt,
                Priority = Entity.Priority,
                Status = Entity.Status,
                AppointmentId = Entity.AppointmentId,

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


        public static WaitingQueueDTO ToDTO(this WaitingQueue Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new WaitingQueueDTO
            {
                Id = Entity.Id,
                PatientId = Entity.PatientId,
                DoctorId = Entity.DoctorId,
                ClinicId = Entity.ClinicId,
                WaitingQueueNumber = Entity.WaitingQueueNumber,
                WaitingQueueDate = Entity.WaitingQueueDate,
                JoinedAt = Entity.JoinedAt,
                CalledAt = Entity.CalledAt,
                ServiceStartAt = Entity.ServiceStartAt,
                CompletedAt = Entity.CompletedAt,
                Priority = Entity.Priority,
                Status = Entity.Status,
                AppointmentId = Entity.AppointmentId,

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
                }

            };
        }

        public static WaitingQueue ToEntity(this WaitingQueueDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new WaitingQueue
            {
                Id = DTO.Id,
                PatientId = DTO.PatientId,
                DoctorId = DTO.DoctorId,
                ClinicId = DTO.ClinicId,
                WaitingQueueNumber = DTO.WaitingQueueNumber,
                WaitingQueueDate = DTO.WaitingQueueDate,
                JoinedAt = DTO.JoinedAt,
                CalledAt = DTO.CalledAt,
                ServiceStartAt = DTO.ServiceStartAt,
                CompletedAt = DTO.CompletedAt,
                Priority = DTO.Priority,
                Status = DTO.Status,
                AppointmentId = DTO.AppointmentId,
            };
        }

        public static void UpdateEntity(this WaitingQueue Entity, WaitingQueueDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.PatientId = DTO.PatientId;
            Entity.DoctorId = DTO.DoctorId;
            Entity.ClinicId = DTO.ClinicId;
            Entity.WaitingQueueNumber = DTO.WaitingQueueNumber;
            Entity.WaitingQueueDate = DTO.WaitingQueueDate;
            Entity.JoinedAt = DTO.JoinedAt;
            Entity.CalledAt = DTO.CalledAt;
            Entity.ServiceStartAt = DTO.ServiceStartAt;
            Entity.CompletedAt = DTO.CompletedAt;
            Entity.Priority = DTO.Priority;
            Entity.Status = DTO.Status;
            Entity.AppointmentId = DTO.AppointmentId;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
