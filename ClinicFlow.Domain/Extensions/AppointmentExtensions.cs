using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class AppointmentExtensions
    {
        public static Expression<Func<Appointment, AppointmentDTO>>
            ToDTOExpression => Entity => new AppointmentDTO
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
                Status = Entity.Status
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
                Status = Entity.Status
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
