using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<AppointmentService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public AppointmentService(
            IAppDbContext appDbContext,
            ILogger<AppointmentService> logger,
            IMemoryCache cache)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(AppointmentDTO DTO)
        {
            try
            {
                var validationResult = await ValidateAppointmentDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.Appointments.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AppointmentService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<AppointmentDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Appointments
                    .AsNoTracking()
                    .Select(AppointmentExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<AppointmentDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AppointmentService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<AppointmentDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<AppointmentDTO>>> GetAllAsync(AppointmentFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.Appointments.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<AppointmentDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AppointmentService),
                   nameof(GetAllAsync));

                return Result<PagedResult<AppointmentDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<AppointmentDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Appointments
                    .AsNoTracking()
                    .Include(x => x.Doctor)
                    .Include(x => x.Patient)
                    .Include(x => x.Clinic)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<AppointmentDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<AppointmentDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AppointmentService),
                   nameof(GetByIdAsync));

                return Result<AppointmentDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, AppointmentDTO DTO)
        {
            try
            {
                var validationResult = await ValidateAppointmentDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Appointments
                    .Include(x => x.Patient)
                    .Include(x => x.Doctor)
                    .Include(x => x.Clinic)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);


                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(AppointmentService),
                    nameof(UpdateAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError, "An unexpected error occurred.");
            }
        }
        #endregion

        #region ========================= Delete =========================
        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Appointments
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.IsDeleted = true;
                item.UpdatedAt = DateTime.UtcNow;
                item.DeletedAt = DateTime.UtcNow;

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(AppointmentService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateAppointmentDTO(AppointmentDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // ======================== AppointmentNumber ========================
            if (string.IsNullOrWhiteSpace(DTO.AppointmentNumber))
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidAppointmentNumber,
                    HttpStatusCodes.BadRequest,
                    "Appointment number is required.");
            }

            var appointmentNumber = DTO.AppointmentNumber.Trim();

            var appointmentNumberExists = await _appDbContext.Appointments
                .AnyAsync(x => x.AppointmentNumber == appointmentNumber &&
                (excludedId == null || x.Id != excludedId.Value));

            if (appointmentNumberExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.AppointmentNumberAlreadyExists,
                    HttpStatusCodes.Conflict,
                    "Appointment number already exists.");
            }

            // ======================== Patient ========================
            if (DTO.PatientId <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PleaseSelectPatient,
                    HttpStatusCodes.BadRequest,
                    "Patient is required.");
            }

            var patientExists = await _appDbContext.Patients
                .AnyAsync(x => x.Id == DTO.PatientId);

            if (!patientExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidPatient,
                    HttpStatusCodes.BadRequest,
                    "Invalid patient.");
            }

            // ======================== Clinic ========================
            if (DTO.ClinicId <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PleaseSelectClinic,
                    HttpStatusCodes.BadRequest,
                    "Clinic is required.");
            }

            var clinicExists = await _appDbContext.Clinics
                .AnyAsync(x => x.Id == DTO.PatientId);

            if (!clinicExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidClinic,
                    HttpStatusCodes.BadRequest,
                    "Invalid clinic.");
            }

            // ======================== Doctor ========================
            if (DTO.DoctorId <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PleaseSelectDoctor,
                    HttpStatusCodes.BadRequest,
                    "Doctor is required.");
            }

            var doctorExists = await _appDbContext.Doctors
                .AnyAsync(x => x.Id == DTO.DoctorId);

            if (!doctorExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidDoctor,
                    HttpStatusCodes.BadRequest,
                    "Invalid doctor.");
            }

            // ======================== Doctor / Clinic ========================
            var doctorAssignedToClinic = await _appDbContext.ClinicDoctors
                .AnyAsync(x =>
                    x.DoctorId == DTO.DoctorId &&
                    x.ClinicId == DTO.ClinicId);

            if (!doctorAssignedToClinic)
            {
                return Result<bool>.Failure(
                    ResultCodes.DoctorNotAssignedToClinic,
                    HttpStatusCodes.BadRequest,
                    "The selected doctor is not assigned to the selected clinic.");
            }

            // ======================== Date / Time ========================
            if (DTO.StartAt >= DTO.EndAt)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidAppointmentTime,
                    HttpStatusCodes.BadRequest,
                    "Start date and time must be before end date and time.");
            }

            // Do not allow creating an appointment in the past.
            if (DTO.StartAt < DateTime.UtcNow)
            {
                return Result<bool>.Failure(
                    ResultCodes.AppointmentInPast,
                    HttpStatusCodes.BadRequest,
                    "Cannot create an appointment in the past.");
            }

            // ======================== Status ========================

            if (!Enum.IsDefined(typeof(AppointmentStatus), DTO.Status))
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidAppointmentStatus,
                    HttpStatusCodes.BadRequest,
                    "Invalid appointment status");
            }

            // ======================== Appointment Overlap ========================
            bool hasOverlap = await _appDbContext.Appointments
                .AnyAsync(x =>
                    x.DoctorId == DTO.DoctorId &&
                    x.Status != AppointmentStatus.Cancelled &&
                    DTO.StartAt < x.EndAt &&
                    DTO.EndAt > x.StartAt &&
                    (excludedId == null || x.Id != excludedId.Value)
                );

            if (hasOverlap)
            {
                return Result<bool>.Failure(
                    ResultCodes.AppointmentTimeAlreadyBooked,
                    HttpStatusCodes.BadRequest,
                    "The selected doctor has another appointment that overlaps with the specified time range.");
            }



            return Result<bool>.Success(true);

        }

        private IQueryable<Appointment> ApplyFilters(
            IQueryable<Appointment> query,
            AppointmentFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    x.AppointmentNumber.Contains(search) ||
                    x.Patient.FullName.Contains(search) ||
                    (x.Patient.PhoneNumber != null &&  x.Patient.PhoneNumber.Contains(search)) ||
                    (x.Patient.Email != null && x.Patient.Email.Contains(search))
                    );
            }

            // ========================== Patient ==========================
            if (filter.PatientId.HasValue)
            {
                query = query.Where(x =>
                    x.PatientId == filter.PatientId.Value);
            }

            // ========================== Doctor ==========================
            if (filter.DoctorId.HasValue)
            {
                query = query.Where(x =>
                    x.DoctorId == filter.DoctorId.Value);
            }

            // ========================== Clinic ==========================
            if (filter.ClinicId.HasValue)
            {
                query = query.Where(x =>
                    x.ClinicId == filter.ClinicId.Value);
            }

            // ========================== FromDate ==========================
            if (filter.FromDate.HasValue)
            {
                query = query.Where(x =>
                    x.StartAt >= filter.FromDate.Value);
            }

            // ========================== ToDate ==========================
            if (filter.ToDate.HasValue)
            {
                // Add one day to include the entire selected date.
                // Example:
                // ToDate = 2026-09-07
                // Before: filters up to 2026-09-07 00:00
                // After:  filters up to 2026-09-08 00:00 (exclusive)
                var toDateInclusive = filter.ToDate.Value.AddDays(1).Date;

                query = query.Where(x =>
                    x.StartAt < toDateInclusive);
            }

            // ========================== Status ==========================
            if (filter.Status.HasValue)
            {
                query = query.Where(x =>
                    x.Status == filter.Status.Value);
            }


            return query;
        }

        private IQueryable<Appointment> ApplySorting(
            IQueryable<Appointment> query,
            AppointmentFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<AppointmentDTO> ProjectToDTO(
            IQueryable<Appointment> query)
        {
            return query.Select(AppointmentExtensions.ToDTOExpression);
        }

        #endregion

    }
}
