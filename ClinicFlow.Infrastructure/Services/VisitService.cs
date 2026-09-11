using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Prescription;
using ClinicFlow.Domain.DTOs.PrescriptionItem;
using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.DTOs.VisitDiagnosis;
using ClinicFlow.Domain.DTOs.VitalSign;
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
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class VisitService : IVisitService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<VisitService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public VisitService(
            IAppDbContext appDbContext,
            ILogger<VisitService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(VisitDTO DTO)
        {
            try
            {
                var validationResult = await ValidateVisitDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                DTO.VisitNumber = await GenerateVisitNumberAsync();

                if (DTO.Prescription != null)
                {
                    DTO.Prescription.PrescriptionNumber = await GeneratePrescriptionNumberAsync();
                }

                var entity = DTO.ToEntity();

                _appDbContext.Visits.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(VisitService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<VisitDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Visits
                    .AsNoTracking()
                    .Select(VisitExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<VisitDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(VisitService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<VisitDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<VisitDTO>>> GetAllAsync(VisitFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.Visits.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<VisitDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(VisitService),
                   nameof(GetAllAsync));

                return Result<PagedResult<VisitDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<VisitDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Visits
                    .AsNoTracking()
                    .Include(x => x.Doctor)
                    .Include(x => x.Patient)
                    .Include(x => x.Clinic)
                    .Include(x => x.VitalSign)
                    .Include(x => x.Prescription)
                        .ThenInclude(x => x.Items)
                    .Include(x => x.VisitDiagnoses)
                        .ThenInclude(x => x.Diagnosis)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<VisitDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<VisitDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(VisitService),
                   nameof(GetByIdAsync));

                return Result<VisitDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, VisitDTO DTO)
        {
            try
            {
                var validationResult = await ValidateVisitDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Visits
                    .Include(x => x.Patient)
                    .Include(x => x.Doctor)
                    .Include(x => x.Clinic)
                    .Include(x => x.WaitingQueue)
                    .Include(x => x.Appointment)
                    .Include(x => x.VitalSign)
                    .Include(x => x.VisitDiagnoses)
                    .Include(x => x.Prescription)
                        .ThenInclude(x => x.Items)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                UpdateVisitDiagnoses(item, DTO);
                await UpdateVisitPrescription(item, DTO);
                UpdateVisitVitalSign(item, DTO);


                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(VisitService),
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
                var item = await _appDbContext.Visits
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
                    nameof(VisitService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================

        private async Task<string> GenerateVisitNumberAsync()
        {
            var now = DateTime.UtcNow;

            var prefix = $"VIS-{now:yyyy-MM}-";

            var lastVisitNumber = await _appDbContext.Visits
                .IgnoreQueryFilters()
                .Where(x => x.VisitNumber.StartsWith(prefix))
                .OrderByDescending(x => x.VisitNumber)
                .Select(x => x.VisitNumber)
                .FirstOrDefaultAsync();

            var nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastVisitNumber))
            {
                var numberPart = lastVisitNumber.Substring(prefix.Length);

                if (int.TryParse(numberPart, out var lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return $"{prefix}{nextNumber:D4}";

        }

        private async Task<string> GeneratePrescriptionNumberAsync()
        {
            var now = DateTime.UtcNow;

            var prefix = $"RX-{now:yyyy-MM}-";

            var lastPrescriptionNumber = await _appDbContext.Prescriptions
                .IgnoreQueryFilters()
                .Where(x => x.PrescriptionNumber.StartsWith(prefix))
                .OrderByDescending(x => x.PrescriptionNumber)
                .Select(x => x.PrescriptionNumber)
                .FirstOrDefaultAsync();

            var nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastPrescriptionNumber))
            {
                var numberPart = lastPrescriptionNumber.Substring(prefix.Length);

                if (int.TryParse(numberPart, out var lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return $"{prefix}{nextNumber:D4}";
        }

        private async Task<Result<bool>> ValidateVisitDTO(VisitDTO DTO, int? excludedId = null)
        {

            // ============== Basic validation ==============
            var basicResult = ValidateVisitBasicFields(DTO);

            if (!basicResult.IsSuccess)
            {
                return basicResult;
            }

            // ============== Patient / Clinic / Doctor ==============
            var personResult = await ValidatePatientClinicDoctorAsync(DTO);

            if (!personResult.IsSuccess)
            {
                return personResult;
            }

            // ============== Existing Visit ==============
            if (excludedId.HasValue)
            {
                var existingVisitResult = await ValidateExistingVisitAsync(DTO, excludedId.Value);

                if (!existingVisitResult.IsSuccess)
                {
                    return existingVisitResult;
                }
            }

            // ============== CompletedAt ==============
            var completedAtResult = ValidateCompletedAt(DTO);

            if (!completedAtResult.IsSuccess)
            {
                return completedAtResult;
            }

            // ============== Appointment ==============
            if (DTO.AppointmentId.HasValue)
            {
                var appointmentResult = await ValidateAppointmentAsync(DTO);

                if (!appointmentResult.IsSuccess)
                {
                    return appointmentResult;
                }
            }

            // ============== Waiting Queue ==============
            if (DTO.WaitingQueueId.HasValue)
            {
                var queueResult = await ValidateWaitingQueueAsync(DTO);

                if (!queueResult.IsSuccess)
                {
                    return queueResult;
                }
            }

            // ============== Diagnoses ==============
            if (DTO.VisitDiagnoses != null)
            {
                var diagnosisResult = await ValidateVisitDiagnosesAsync(DTO);

                if (!diagnosisResult.IsSuccess)
                {
                    return diagnosisResult;
                }
            }

            // ============== Prescriptions ==============
            if (DTO.Prescription != null)
            {
                var prescriptionResult = await ValidatePrescriptionAsync(DTO);
                
                if (!prescriptionResult.IsSuccess)
                {
                    return prescriptionResult;
                }
            }

            return Result<bool>.Success(true);

        }

        private Result<bool> ValidateVisitBasicFields(VisitDTO DTO) 
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

            // ======================== Clinic ========================
            if (DTO.ClinicId <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PleaseSelectClinic,
                    HttpStatusCodes.BadRequest,
                    "Clinic is required.");
            }

            // ======================== Doctor ========================
            if (DTO.DoctorId <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PleaseSelectDoctor,
                    HttpStatusCodes.BadRequest,
                    "Doctor is required.");
            }

            // ======================== Visit Date ========================
            if (DTO.VisitDate == default)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidVisitDate,
                    HttpStatusCodes.BadRequest,
                    "Visit date is required"
                    );
            }

            // ======================== Status ========================

            if (!Enum.IsDefined(typeof(VisitStatus), DTO.Status))
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidVisitStatus,
                    HttpStatusCodes.BadRequest,
                    "Invalid visit status");
            }


            return Result<bool>.Success(true);

        }

        private async Task<Result<bool>> ValidatePatientClinicDoctorAsync(VisitDTO DTO) 
        {

            // ======================== Patient ========================
            var patientExists = await _appDbContext.Patients
                .AnyAsync(x => x.Id == DTO.PatientId);

            if (!patientExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidPatient,
                    HttpStatusCodes.BadRequest,
                    "Invalid patient.");
            }

            // ======================== Doctor ========================
            var doctorExists = await _appDbContext.Doctors
                .AnyAsync(x => x.Id == DTO.DoctorId && x.IsActive);

            if (!doctorExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidDoctor,
                    HttpStatusCodes.BadRequest,
                    "Invalid doctor.");
            }

            // ======================== Clinic ========================
            var clinicExists = await _appDbContext.Clinics
                .AnyAsync(x => x.Id == DTO.ClinicId && x.IsActive);

            if (!clinicExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidClinic,
                    HttpStatusCodes.BadRequest,
                    "Invalid clinic.");
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

            return Result<bool>.Success(true);

        }

        private async Task<Result<bool>> ValidateExistingVisitAsync(VisitDTO DTO, int excludedId) 
        {
            // ======================== Existing Visit ========================

            // Used mainly during update to validate status transitions.
            var existingVisit = await _appDbContext.Visits
                    .AsNoTracking()
                    .Where(x => x.Id == excludedId)
                    .Select(x => new
                    {
                        x.Id,
                        x.Status
                    })
                    .FirstOrDefaultAsync();

            if (existingVisit == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.VisitNotFound,
                    HttpStatusCodes.NotFound,
                    "Visit not found");
            }


            // A completed visit should not be changed back to Open.
            if (existingVisit.Status == VisitStatus.Completed &&
                DTO.Status != VisitStatus.Completed)
            {
                return Result<bool>.Failure(
                    ResultCodes.VisitAlreadyCompleted,
                    HttpStatusCodes.BadRequest,
                    "A completed visit cannot be changed to another status");
            }

            // A cancelled visit should not be reopened.
            if (existingVisit.Status == VisitStatus.Cancelled &&
                DTO.Status != VisitStatus.Cancelled)
            {
                return Result<bool>.Failure(
                    ResultCodes.VisitAlreadyCancelled,
                    HttpStatusCodes.BadRequest,
                    "A cancelled visit cannot be reopened");
            }

            return Result<bool>.Success(true);


        }

        private Result<bool> ValidateCompletedAt(VisitDTO DTO) 
        {
            // ======================== CompletedAt ========================

            // CompletedAt should only be supplied for completed visits.
            if (DTO.Status != VisitStatus.Completed &&
                DTO.CompletedAt.HasValue)
            {
                return Result<bool>.Failure(
                        ResultCodes.InvalidData,
                        HttpStatusCodes.BadRequest,
                        "CompletedAt can only be set for a completed visit");
            }

            // If CompletedAt is supplied for a completed visit, 
            // make sure it is not default.
            if (DTO.Status == VisitStatus.Completed &&
                DTO.CompletedAt.HasValue &&
                DTO.CompletedAt.Value == default)
            {
                return Result<bool>.Failure(
                        ResultCodes.InvalidData,
                        HttpStatusCodes.BadRequest,
                        "Invalid completion date");
            }

            return Result<bool>.Success(true);
        }

        private async Task<Result<bool>> ValidateAppointmentAsync(VisitDTO DTO, int? excludedId = null) 
        {
            // ======================== Appointment ========================
            if (!DTO.AppointmentId.HasValue)
            {
                return Result<bool>.Success(true);
            }

            if (DTO.AppointmentId.Value <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidAppointment,
                    HttpStatusCodes.BadRequest,
                    "Invalid appointment");
            }

            var appointment = await _appDbContext.Appointments
                .AsNoTracking()
                .Where(x => x.Id == DTO.AppointmentId.Value)
                .Select(x => new
                {
                    x.Id,
                    x.PatientId,
                    x.DoctorId,
                    x.ClinicId
                })
                .FirstOrDefaultAsync();

            if (appointment == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidAppointment,
                    HttpStatusCodes.BadRequest,
                    "Invalid appointment");
            }

            // Make sure appointment belongs to same patient
            if (appointment.PatientId != DTO.PatientId)
            {
                return Result<bool>.Failure(
                    ResultCodes.AppointmentPatientMismatch,
                    HttpStatusCodes.BadRequest,
                    "The appointment does not belong to the selected patient");
            }

            // Make sure appointment belongs to same doctor
            if (appointment.DoctorId != DTO.DoctorId)
            {
                return Result<bool>.Failure(
                    ResultCodes.AppointmentDoctorMismatch,
                    HttpStatusCodes.BadRequest,
                    "The appointment does not belong to the selected doctor");
            }

            // Make sure appointment belongs to same clinic
            if (appointment.ClinicId != DTO.ClinicId)
            {
                return Result<bool>.Failure(
                    ResultCodes.AppointmentClinicMismatch,
                    HttpStatusCodes.BadRequest,
                    "The appointment does not belong to the selected clinic");
            }

            var appointmentAlreadyUsed = await _appDbContext.Visits
                .AsNoTracking()
                .AnyAsync(x =>
                    x.AppointmentId == DTO.AppointmentId.Value &&
                    (!excludedId.HasValue || x.Id != excludedId.Value));

            if (appointmentAlreadyUsed)
            {
                return Result<bool>.Failure(
                    ResultCodes.AppointmentAlreadyUsed,
                    HttpStatusCodes.BadRequest,
                    "This appointment is already linked to another visit");
            }

            return Result<bool>.Success(true);
        }

        private async Task<Result<bool>> ValidateWaitingQueueAsync(VisitDTO DTO) 
        {
            // ======================== Waiting Queue ========================
            if (!DTO.WaitingQueueId.HasValue)
            {
                return Result<bool>.Success(true);
            }

            if (DTO.WaitingQueueId.Value <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidWaitingQueue,
                    HttpStatusCodes.BadRequest,
                    "Invalid waiting queue.");
            }


            var queueExists = await _appDbContext.WaitingQueues
                .AsNoTracking()
                .AnyAsync(x =>
                    x.Id == DTO.WaitingQueueId.Value);

            if (!queueExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidWaitingQueue,
                    HttpStatusCodes.BadRequest,
                    "Invalid waiting queue.");
            }

            return Result<bool>.Success(true);
        }

        private async Task<Result<bool>> ValidateVisitDiagnosesAsync(
            VisitDTO DTO) 
        {
            // ======================== Visit Diagnoses ========================
            if (DTO.VisitDiagnoses == null ||
                !DTO.VisitDiagnoses.Any())
            {
                return Result<bool>.Success(true);
            }

            var diagnoses = DTO.VisitDiagnoses.ToList();

            // ============ Required ID ============
            if (diagnoses.Any(x => x.DiagnosisId <= 0))
            {
                return Result<bool>.Failure(
                        ResultCodes.InvalidDiagnosis,
                        HttpStatusCodes.BadRequest,
                        "Invalid diagnosis.");
            }

            // ============ Duplicate Diagnosis ============
            var hasDuplicateDiagnosis = diagnoses
                .GroupBy(x => x.DiagnosisId)
                .Any(x => x.Count() > 1);

            if (hasDuplicateDiagnosis)
            {
                return Result<bool>.Failure(
                        ResultCodes.DuplicateDiagnosis,
                        HttpStatusCodes.BadRequest,
                        "The same diagnosis cannot be added more than once.");
            }

            // ============ Collect IDs ============

            var diagnosisIds = diagnoses
                .Select(x => x.DiagnosisId)
                .Distinct()
                .ToList()
                ?? new List<int>();

            // ============ ONE Database Query ============
            var existingDiagnosisIds = await _appDbContext.Diagnoses
                .AsNoTracking()
                .Where(x => diagnosisIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToListAsync();

            // ============ Compare ============
            if (existingDiagnosisIds.Count != diagnosisIds.Count)
            {
                return Result<bool>.Failure(
                        ResultCodes.InvalidDiagnosis,
                        HttpStatusCodes.BadRequest,
                        "One or more selected diagnoses are invalid.");
            }


            return Result<bool>.Success(true);
        }

        private async Task<Result<bool>> ValidatePrescriptionAsync(VisitDTO DTO) 
        {
            // ======================== Prescriptions ========================
            if (DTO.Prescription == null)
            {
                return Result<bool>.Success(true);
            }

            // ========================================================
            // First validate everything that does NOT require DB
            // ========================================================
            // ============= Prescription Date =============
            if (DTO.Prescription.PrescriptionDate == default)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidPrescriptionDate,
                    HttpStatusCodes.BadRequest,
                    "Prescription date is required.");
            }

            // ============= Prescription Items =============
            if (DTO.Prescription.Items == null ||
                !DTO.Prescription.Items.Any())
            {
                return Result<bool>.Failure(
                    ResultCodes.PrescriptionItemsRequired,
                    HttpStatusCodes.BadRequest,
                    "Prescription must contain at least one item.");
            }

            foreach (var item in DTO.Prescription.Items)
            {
                // ================= MedicineId =================
                if (item.MedicineId <= 0)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidMedicine,
                        HttpStatusCodes.BadRequest,
                        "Medicine is required.");
                }

                // ================= Quantity =================
                if (item.Quantity <= 0)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidPrescriptionQuantity,
                        HttpStatusCodes.BadRequest,
                        "Prescription quantity must be greater than zero");
                }

                // ================= Dosage =================
                if (string.IsNullOrWhiteSpace(item.Dosage))
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidPrescriptionDosage,
                        HttpStatusCodes.BadRequest,
                        "Prescription dosage is required");
                }

                // ================= Frequency =================
                if (string.IsNullOrWhiteSpace(item.Frequency))
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidPrescriptionFrequency,
                        HttpStatusCodes.BadRequest,
                        "Prescription frequency is required");
                }
                // ================= Duration =================
                if (string.IsNullOrWhiteSpace(item.Duration))
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidPrescriptionDuration,
                        HttpStatusCodes.BadRequest,
                        "Prescription duration is required");
                }
            }

            // ========================================================
            // Collect ALL medicine IDs
            // ========================================================
            var medicineIds = DTO.Prescription.Items
                .Select(x => x.MedicineId)
                .Distinct()
                .ToList();

            // ========================================================
            // ONE database query for ALL medicines
            // ========================================================
            var existingMedicineIds =
                await _appDbContext.Medicines
                    .AsNoTracking()
                    .Where(x => medicineIds.Contains(x.Id))
                    .Select(x => x.Id)
                    .ToListAsync();

            // ========================================================
            // Compare
            // ========================================================
            if (existingMedicineIds.Count != medicineIds.Count)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidMedicine,
                    HttpStatusCodes.BadRequest,
                    "Invalid medicine.");
            }

            return Result<bool>.Success(true);
        }

        private IQueryable<Visit> ApplyFilters(
            IQueryable<Visit> query,
            VisitFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    x.VisitNumber.Contains(search) ||
                    x.Patient.FullName.Contains(search) ||
                    (x.Patient.PhoneNumber != null && x.Patient.PhoneNumber.Contains(search)) ||
                    (x.Patient.Email != null && x.Patient.Email.Contains(search)) ||
                    (x.Doctor.FullName != null && x.Doctor.FullName.Contains(search)) ||
                    (x.Doctor.PhoneNumber != null && x.Doctor.PhoneNumber.Contains(search)) ||
                    (x.Doctor.Email != null && x.Doctor.Email.Contains(search)) ||
                    (x.Clinic != null && (x.Clinic.NameEn.Contains(search) || (x.Clinic.NameAr.Contains(search)))) 
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


            return query;
        }

        private IQueryable<Visit> ApplySorting(
            IQueryable<Visit> query,
            VisitFilterDTO filter)
        {
            bool desc = filter.Descending;

            var currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

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

        private IQueryable<VisitDTO> ProjectToDTO(
            IQueryable<Visit> query)
        {
            return query.Select(VisitExtensions.ToDTOExpression);
        }

        private void UpdateVisitVitalSign(Visit Entity, VisitDTO DTO)
        {
            // No VitalSign was selected/submitted
            if (DTO.VitalSign == null)
            {
                if (Entity.VitalSign != null)
                {
                    _appDbContext.VitalSigns.Remove(Entity.VitalSign);
                }

                return;
            }

            // VitalSign was selected but does not exist yet
            if (Entity.VitalSign == null)
            {
                Entity.VitalSign = new VitalSign
                {
                    Temperature = DTO.VitalSign.Temperature,
                    Pulse = DTO.VitalSign.Pulse,
                    SystolicBloodPressure = DTO.VitalSign.SystolicBloodPressure,
                    DiastolicBloodPressure = DTO.VitalSign.DiastolicBloodPressure,
                    RespiratoryRate = DTO.VitalSign.RespiratoryRate,
                    OxygenSaturation = DTO.VitalSign.OxygenSaturation,
                    Weight = DTO.VitalSign.Weight,
                    Height = DTO.VitalSign.Height,
                    RecordedAt = DTO.VitalSign.RecordedAt
                };

                return;
            }


            // Existing VitalSign -> update
            Entity.VitalSign.Temperature = DTO.VitalSign.Temperature;
            Entity.VitalSign.Pulse = DTO.VitalSign.Pulse;
            Entity.VitalSign.SystolicBloodPressure = DTO.VitalSign.SystolicBloodPressure;
            Entity.VitalSign.DiastolicBloodPressure = DTO.VitalSign.DiastolicBloodPressure;
            Entity.VitalSign.RespiratoryRate = DTO.VitalSign.RespiratoryRate;
            Entity.VitalSign.OxygenSaturation = DTO.VitalSign.OxygenSaturation;
            Entity.VitalSign.Weight = DTO.VitalSign.Weight;
            Entity.VitalSign.Height = DTO.VitalSign.Height;
            Entity.VitalSign.RecordedAt = DTO.VitalSign.RecordedAt;
            Entity.VitalSign.UpdatedAt = DateTime.Now;

        }

        private void UpdateVisitDiagnoses(Visit Entity, VisitDTO DTO)
        {
            var incomingIds = DTO.VisitDiagnoses?
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet()
                ?? new HashSet<int>();

            // ======================== Remove ========================
            var deletedItems = Entity.VisitDiagnoses
                .Where(x => x.Id > 0 && !incomingIds.Contains(x.Id)).ToList();

            _appDbContext.VisitDiagnoses.RemoveRange(deletedItems);

            // ======================== Add / Update ========================
            foreach (var dto in DTO.VisitDiagnoses 
                ?? Enumerable.Empty<VisitDiagnosisDTO>())
            {
                var entity = Entity.VisitDiagnoses
                    .FirstOrDefault(x => x.Id == dto.Id);

                // ======================== Add ========================
                if (entity == null)
                {
                    Entity.VisitDiagnoses.Add(new VisitDiagnosis
                    {
                        DiagnosisId = dto.DiagnosisId,
                        Notes = dto.Notes,
                    });

                    continue;
                }

                // ======================== Update ========================
                entity.DiagnosisId = dto.DiagnosisId;
                entity.Notes = dto.Notes;
            }
        }

        private async Task UpdateVisitPrescription(Visit Entity, VisitDTO DTO)
        {
            // No prescription was selected/submitted
            if (DTO.Prescription == null)
            {
                if (Entity.Prescription != null)
                {
                    _appDbContext.Prescriptions.Remove(Entity.Prescription);
                }

                return;
            }


            // Prescription was selected but does not exist yet
            if (Entity.Prescription == null)
            {
                Entity.Prescription = new Prescription
                {
                    PrescriptionDate = DateTime.Now,
                    PrescriptionNumber = await GeneratePrescriptionNumberAsync(),
                    Notes = DTO.Prescription.Notes,
                };

                UpdatePrescriptionItems(Entity.Prescription, DTO.Prescription);

                return;
            }

            // Existing prescription -> update
            Entity.Prescription.PrescriptionDate = DateTime.Now;
            Entity.Prescription.Notes = DTO.Prescription.Notes;
            UpdatePrescriptionItems(Entity.Prescription, DTO.Prescription);

        }

        private void UpdatePrescriptionItems(Prescription Entity, PrescriptionDTO DTO)
        {
            var incomingIds = DTO.Items?
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet()
                ?? new HashSet<int>();

            // ======================== Remove ========================
            var deletedItems = Entity.Items
                .Where(x => x.Id > 0 &&
                    !incomingIds.Contains(x.Id))
                .ToList();

            _appDbContext.PrescriptionItems.RemoveRange(deletedItems);

            // ======================== Add / Update ========================
            foreach (var dto in DTO.Items
                ?? Enumerable.Empty<PrescriptionItemDTO>())
            {
                var item = Entity.Items.FirstOrDefault(x => x.Id == dto.Id);
                // ======================== Add ========================
                if (item == null)
                {
                    Entity.Items.Add(new PrescriptionItem
                    {
                        MedicineId = dto.MedicineId,
                        MedicineName = dto.MedicineName,
                        Dosage = dto.Dosage,
                        Frequency = dto.Frequency,
                        Duration = dto.Duration,
                        Instructions = dto.Instructions,
                        Quantity = dto.Quantity,
                    });

                    continue;
                }

                // ======================== Update ========================
                item.MedicineId = dto.MedicineId;
                item.MedicineName = dto.MedicineName;
                item.Dosage = dto.Dosage;
                item.Frequency = dto.Frequency;
                item.Duration = dto.Duration;
                item.Instructions = dto.Instructions;
                item.Quantity = dto.Quantity;

            }

        }

        #endregion

    }
}
