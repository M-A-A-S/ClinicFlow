using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.WaitingQueue;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class WaitingQueueService : IWaitingQueueService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<WaitingQueueService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public WaitingQueueService(
            IAppDbContext appDbContext,
            ILogger<WaitingQueueService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(WaitingQueueDTO DTO)
        {
            try
            {
                var validationResult = await ValidateWaitingQueueDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                DTO.WaitingQueueNumber = await GenerateWaitingQueueNumberAsync(DTO);

                var entity = DTO.ToEntity();

                _appDbContext.WaitingQueues.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(WaitingQueueService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<WaitingQueueDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.WaitingQueues
                    .AsNoTracking()
                    .Select(WaitingQueueExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<WaitingQueueDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(WaitingQueueService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<WaitingQueueDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<WaitingQueueDTO>>> GetAllAsync(WaitingQueueFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.WaitingQueues.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<WaitingQueueDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(WaitingQueueService),
                   nameof(GetAllAsync));

                return Result<PagedResult<WaitingQueueDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<WaitingQueueDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.WaitingQueues
                    .AsNoTracking()
                    .Include(x => x.Doctor)
                    .Include(x => x.Patient)
                    .Include(x => x.Clinic)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<WaitingQueueDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<WaitingQueueDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(WaitingQueueService),
                   nameof(GetByIdAsync));

                return Result<WaitingQueueDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, WaitingQueueDTO DTO)
        {
            try
            {
                var validationResult = await ValidateWaitingQueueDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.WaitingQueues
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
                    nameof(WaitingQueueService),
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
                var item = await _appDbContext.WaitingQueues
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
                    nameof(WaitingQueueService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================

        private async Task<int> GenerateWaitingQueueNumberAsync(
            WaitingQueueDTO DTO)
        {

            var lastNumber = await _appDbContext.WaitingQueues
                .IgnoreQueryFilters()
                .Where(x =>
                    x.WaitingQueueDate == DTO.WaitingQueueDate &&
                    x.ClinicId == DTO.ClinicId &&
                    x.DoctorId == DTO.DoctorId)
                .MaxAsync(x => (int?)x.WaitingQueueNumber);

            return (lastNumber ?? 0) + 1;
        }

        private async Task<Result<bool>> ValidateWaitingQueueDTO(WaitingQueueDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
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
                .AnyAsync(x => x.Id == DTO.ClinicId && x.IsActive);

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
                .AnyAsync(x => x.Id == DTO.DoctorId && x.IsActive);

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

            // ======================== Doctor / Clinic / Patient / Date ========================
            var hasExistingQueue = await _appDbContext.WaitingQueues
                .AnyAsync(x =>
                    x.PatientId == DTO.PatientId &&
                    x.ClinicId == DTO.ClinicId &&
                    x.DoctorId == DTO.DoctorId &&
                    x.WaitingQueueDate == DTO.WaitingQueueDate &&

                    x.Status != QueueStatus.Completed &&
                    x.Status != QueueStatus.Cancelled &&
                    x.Status != QueueStatus.NoShow &&

                    (!excludedId.HasValue || x.Id != excludedId.Value)
                );

            if (hasExistingQueue)
            {
                return Result<bool>.Failure(
                    ResultCodes.PatientAlreadyInWaitingQueue,
                    HttpStatusCodes.BadRequest);
            }


            // ======================== Waiting Queue Date ========================
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            if (DTO.WaitingQueueDate < today)
            {
                return Result<bool>.Failure(
                    ResultCodes.WaitingQueueDateInPast,
                    HttpStatusCodes.BadRequest,
                    "Waiting queue date cannot be in the past.");
            }


            // ======================== Status ========================

            if (!Enum.IsDefined(typeof(QueueStatus), DTO.Status))
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidWaitingQueueStatus,
                    HttpStatusCodes.BadRequest,
                    "Invalid waiting queue status");
            }

            return Result<bool>.Success(true);

        }

        private IQueryable<WaitingQueue> ApplyFilters(
            IQueryable<WaitingQueue> query,
            WaitingQueueFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    x.Patient.FullName.Contains(search) ||

                    (x.Patient.PhoneNumber != null && x.Patient.PhoneNumber.Contains(search)) ||
                    
                    (x.Patient.Email != null && x.Patient.Email.Contains(search)) ||
                    
                    (x.Doctor.FullName != null && x.Doctor.FullName.Contains(search)) ||
                    
                    (x.Doctor.PhoneNumber != null && x.Doctor.PhoneNumber.Contains(search)) ||
                    
                    (x.Doctor.Email != null && x.Doctor.Email.Contains(search))
                    
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

            // ========================== WaitingQueueDate ==========================
            query = query.Where(x =>
                x.WaitingQueueDate == filter.WaitingQueueDate);

            // ========================== FromDate ==========================
            if (filter.FromDate.HasValue)
            {
                query = query.Where(x =>
                    x.CreatedAt >= filter.FromDate.Value);
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
                    x.CreatedAt < toDateInclusive);
            }

            // ========================== Status ==========================
            if (filter.Status.HasValue)
            {
                query = query.Where(x =>
                    x.Status == filter.Status.Value);
            }

            // ========================== Priority ==========================
            if (filter.Priority.HasValue)
            {
                query = query.Where(x =>
                    x.Priority == filter.Priority.Value);
            }

            // ========================== WaitingQueueNumber ==========================
            if (filter.WaitingQueueNumber.HasValue)
            {
                query = query.Where(x =>
                    x.WaitingQueueNumber == filter.WaitingQueueNumber.Value);
            }


            return query;
        }

        private IQueryable<WaitingQueue> ApplySorting(
            IQueryable<WaitingQueue> query,
            WaitingQueueFilterDTO filter)
        {
            bool desc = filter.Descending;

            var currentLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            var isArabic = currentLanguage.Equals("ar", StringComparison.OrdinalIgnoreCase);

            return filter.SortBy switch
            {
                "PatientId" => desc
                    ? query.OrderByDescending(x => x.Patient.FullName)
                    : query.OrderBy(x => x.Patient.FullName),

                "DoctorId" => desc
                    ? query.OrderByDescending(x => x.Doctor.FullName)
                    : query.OrderBy(x => x.Doctor.FullName),

                "ClinicId" => isArabic
                    ? (desc 
                        ? query.OrderByDescending(x => x.Clinic.NameAr)
                        : query.OrderBy(x => x.Clinic.NameAr)
                    ) :
                    (desc 
                        ? query.OrderByDescending(x => x.Clinic.NameEn)
                        : query.OrderBy(x => x.Clinic.NameEn)
                    ),

                _ => query.OrderByProperty(filter.SortBy, desc)
            };
        }

        private IQueryable<WaitingQueueDTO> ProjectToDTO(
            IQueryable<WaitingQueue> query)
        {
            return query.Select(WaitingQueueExtensions.ToDTOExpression);
        }

        #endregion

    }
}
