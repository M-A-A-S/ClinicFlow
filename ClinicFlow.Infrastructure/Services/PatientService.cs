using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Entities;
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
    public class PatientService : IPatientService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<PatientService> _logger;
        private readonly IMemoryCache _cache;

        #endregion

        #region ========================= Constructors =========================
        public PatientService(
            IAppDbContext appDbContext,
            ILogger<PatientService> logger,
            IMemoryCache cache)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _cache = cache;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(PatientDTO DTO)
        {
            try
            {
                var validationResult = await ValidatePatientDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.Patients.Add(entity);
                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.PatientSelect);
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PatientService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<PatientDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Patients
                    .AsNoTracking()
                    .Select(PatientExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<PatientDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PatientService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<PatientDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<PatientDTO>>> GetAllAsync(PatientFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.Patients.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<PatientDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PatientService),
                   nameof(GetAllAsync));

                return Result<PagedResult<PatientDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PatientDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Patients
                    .AsNoTracking()
                    .Include(x => x.PatientAllergies)
                    .Include(x => x.PatientChronicConditions)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<PatientDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<PatientDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PatientService),
                   nameof(GetByIdAsync));

                return Result<PatientDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<PatientSearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.Patients
                .AsNoTracking();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var term = search.Trim();
                    query = query.Where(x =>
                        x.FullName.Contains(term) ||
                        (x.PhoneNumber != null && x.PhoneNumber.Contains(term)) ||
                        (x.Email != null && x.Email.Contains(term)) || 
                        (x.Address != null && x.Address.Contains(term)) || 
                        (x.NationalId != null && x.NationalId.Contains(term))
                       );
                }

                var items = await query
                    .Take(20)
                    .Select(x => new PatientSearchDTO
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                        PhoneNumber = x.PhoneNumber,
                    })
                    .ToListAsync();

                return Result<IEnumerable<PatientSearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(PatientService), nameof(SearchAsync));
                return Result<IEnumerable<PatientSearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }

        public async Task<Result<IEnumerable<PatientSearchDTO>>> GetForSelectAsync()
        {
            try
            {
                if (_cache.TryGetValue(
                    CacheKeys.PatientSelect,
                    out IEnumerable<PatientSearchDTO>? items))
                {
                    return Result<IEnumerable<PatientSearchDTO>>
                        .Success(items);
                }


                items = await _appDbContext.Patients
                    .AsNoTracking()
                    .OrderBy(x => x.FullName)
                    .Select(x => new PatientSearchDTO
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                        PhoneNumber = x.PhoneNumber,
                    })
                    .ToListAsync();


                _cache.Set(
                    CacheKeys.PatientSelect,
                    items,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
                    });


                return Result<IEnumerable<PatientSearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<PatientSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, PatientDTO DTO)
        {
            try
            {
                var validationResult = await ValidatePatientDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Patients
                    .Include(x => x.PatientAllergies)
                    .Include(x => x.PatientChronicConditions)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                UpdatePatientAllergies(item, DTO);

                UpdatePatientChronicConditions(item, DTO);

                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.PatientSelect);
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(PatientService),
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
                var item = await _appDbContext.Patients
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
                _cache.Remove(CacheKeys.PatientSelect);
                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(PatientService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidatePatientDTO(PatientDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }


            // ======================== DateOfBirth ========================
            if (DTO.DateOfBirth.HasValue && 
                DTO.DateOfBirth.Value.Date > DateTime.UtcNow.Date)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidDate,
                    HttpStatusCodes.BadRequest,
                    "Date of birth cannot be in the future.");
            }

            // ======================== PhoneNumber ========================
            if (!string.IsNullOrWhiteSpace(DTO.PhoneNumber))
            {
                var phoneNumber = DTO.PhoneNumber.Trim();

                var phoneNumberExists = await _appDbContext.Patients
                    .AnyAsync(x => x.PhoneNumber == phoneNumber &&
                    (excludedId == null || x.Id != excludedId.Value));

                if (phoneNumberExists)
                {
                    return Result<bool>.Failure(
                        ResultCodes.PhoneNumberAlreadyExists,
                        HttpStatusCodes.Conflict,
                        "Phone number already exists.");
                }
            }

            // ======================== Email ========================
            if (!string.IsNullOrWhiteSpace(DTO.Email))
            {
                var email = DTO.Email.Trim();

                var emailExists = await _appDbContext.Patients
                    .AnyAsync(x => x.Email == email &&
                    (excludedId == null || x.Id != excludedId.Value));

                if (emailExists)
                {
                    return Result<bool>.Failure(
                        ResultCodes.EmailAlreadyExists,
                        HttpStatusCodes.Conflict,
                        "Email already exists.");
                }
            }

            // ======================== NationalId ========================
            if (!string.IsNullOrWhiteSpace(DTO.NationalId))
            {
                var nationalId= DTO.NationalId.Trim();

                var nationalIdExists = await _appDbContext.Patients
                    .AnyAsync(x => x.NationalId == nationalId &&
                    (excludedId == null || x.Id != excludedId));

                if (nationalIdExists)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NationalIdAlreadyExists,
                        HttpStatusCodes.Conflict,
                        "NationalId already exists.");
                }
            }

            // ======================== Allergies ========================
            var allergyIds = DTO.PatientAllergies
                .Select(x => x.AllergyId)
                .ToList();

            var distinctAllergyIds = allergyIds
                .Distinct()
                .ToList();

            if (allergyIds.Count != distinctAllergyIds.Count)
            {
                return Result<bool>.Failure(
                    ResultCodes.DuplicateAllergy,
                    HttpStatusCodes.BadRequest,
                    "Duplicate allergy IDs found.");
            }

            if (distinctAllergyIds.Count > 0)
            {
                var validAllergyCount = await _appDbContext.Allergies
                .CountAsync(x => distinctAllergyIds.Contains(x.Id));

                if (validAllergyCount != distinctAllergyIds.Count)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidAllergy,
                        HttpStatusCodes.BadRequest,
                        "One or more allergy IDs are invalid.");
                }
            }



            // ======================== Chronic Conditions ========================
            var chronicConditionIds = DTO.PatientChronicConditions
                .Select(x => x.ChronicConditionId)
                .ToList();

            var distinctChronicConditionIds = chronicConditionIds
                .Distinct()
                .ToList();

            if (chronicConditionIds.Count != distinctChronicConditionIds.Count)
            {
                return Result<bool>.Failure(
                    ResultCodes.DuplicateChronicCondition,
                    HttpStatusCodes.BadRequest,
                    "Duplicate chronic condition IDs found.");
            }

            if (distinctChronicConditionIds.Count > 0)
            {
                var validChronicConditionCount = await _appDbContext.ChronicConditions
                .CountAsync(x => distinctChronicConditionIds.Contains(x.Id));

                if (validChronicConditionCount != distinctChronicConditionIds.Count)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidChronicCondition,
                        HttpStatusCodes.BadRequest,
                        "One or more chronic condition IDs are invalid.");
                }
            }
            

            return Result<bool>.Success(true);

        }

        private IQueryable<Patient> ApplyFilters(
            IQueryable<Patient> query,
            PatientFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();
                query = query.Where(x =>
                    x.FullName.Contains(search) ||
                    (x.PhoneNumber != null && x.PhoneNumber.Contains(search)) || 
                    (x.Email != null && x.Email.Contains(search)) ||
                    (x.Address != null && x.Address.Contains(search)) ||
                    (x.NationalId != null && x.NationalId.Contains(search))
                    );
            }

            return query;
        }

        private IQueryable<Patient> ApplySorting(
            IQueryable<Patient> query,
            PatientFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<PatientDTO> ProjectToDTO(
            IQueryable<Patient> query)
        {
            return query.Select(PatientExtensions.ToDTOExpression);
        }

        private void UpdatePatientAllergies(Patient Entity, PatientDTO DTO)
        {
            _appDbContext.PatientAllergies
                .RemoveRange(Entity.PatientAllergies);

            Entity.PatientAllergies.Clear();

            foreach (var allergy in DTO.PatientAllergies)
            {
                Entity.PatientAllergies.Add(new PatientAllergy
                {
                    AllergyId = allergy.AllergyId,
                    Notes = allergy.Notes,
                    IdentifiedAt =
                        allergy.IdentifiedAt ?? DateTime.UtcNow,
                });
            }
        }

        private void UpdatePatientChronicConditions(Patient Entity, PatientDTO DTO)
        {
            _appDbContext.PatientChronicConditions
                .RemoveRange(Entity.PatientChronicConditions);

            Entity.PatientChronicConditions.Clear();

            foreach (var condition in DTO.PatientChronicConditions)
            {
                Entity.PatientChronicConditions.Add(
                    new PatientChronicCondition
                    {
                        ChronicConditionId =
                            condition.ChronicConditionId,

                        Notes = condition.Notes,

                        DiagnosedAt =
                            condition.DiagnosedAt ?? DateTime.UtcNow,
                    });
            }
        }

        #endregion

    }
}
