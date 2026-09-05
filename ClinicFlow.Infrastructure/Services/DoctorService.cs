using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Doctor;
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
    public class DoctorService : IDoctorService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<DoctorService> _logger;
        private readonly IMemoryCache _cache;

        #endregion

        #region ========================= Constructors =========================
        public DoctorService(
            IAppDbContext appDbContext,
            ILogger<DoctorService> logger,
            IMemoryCache cache)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _cache = cache;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(DoctorDTO DTO)
        {
            try
            {
                var validationResult = await ValidateDoctorDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.Doctors.Add(entity);
                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.DoctorSelect);
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(DoctorService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<DoctorDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Doctors
                    .AsNoTracking()
                    .Select(DoctorExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<DoctorDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(DoctorService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<DoctorDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<DoctorDTO>>> GetAllAsync(DoctorFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.Doctors.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<DoctorDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(DoctorService),
                   nameof(GetAllAsync));

                return Result<PagedResult<DoctorDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<DoctorDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Doctors
                    .AsNoTracking()
                    .Include(x => x.DoctorSpecialties)
                        .ThenInclude(x => x.Specialty)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<DoctorDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<DoctorDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(DoctorService),
                   nameof(GetByIdAsync));

                return Result<DoctorDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<DoctorSearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.Doctors
                .AsNoTracking();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var term = search.Trim();
                    query = query.Where(x =>
                        x.FullName.Contains(term) ||
                        (x.PhoneNumber != null && x.PhoneNumber.Contains(term)) ||
                        (x.Email != null && x.Email.Contains(term))
                       );
                }

                var items = await query
                    .Take(20)
                    .Select(x => new DoctorSearchDTO
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                        PhoneNumber = x.PhoneNumber,
                    })
                    .ToListAsync();

                return Result<IEnumerable<DoctorSearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(DoctorService), nameof(SearchAsync));
                return Result<IEnumerable<DoctorSearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }

        public async Task<Result<IEnumerable<DoctorSearchDTO>>> GetForSelectAsync()
        {
            try
            {
                if (_cache.TryGetValue(
                    CacheKeys.DoctorSelect,
                    out IEnumerable<DoctorSearchDTO>? items))
                {
                    return Result<IEnumerable<DoctorSearchDTO>>
                        .Success(items);
                }


                items = await _appDbContext.Doctors
                    .AsNoTracking()
                    .OrderBy(x => x.FullName)
                    .Select(x => new DoctorSearchDTO
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                        PhoneNumber = x.PhoneNumber,
                    })
                    .ToListAsync();


                _cache.Set(
                    CacheKeys.DoctorSelect,
                    items,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
                    });


                return Result<IEnumerable<DoctorSearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<DoctorSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, DoctorDTO DTO)
        {
            try
            {
                var validationResult = await ValidateDoctorDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Doctors
                    .Include(x => x.DoctorSpecialties)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                UpdateDoctorSpecialties(item, DTO);

                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.DoctorSelect);
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(DoctorService),
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
                var item = await _appDbContext.Doctors
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
                _cache.Remove(CacheKeys.DoctorSelect);
                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(DoctorService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateDoctorDTO(DoctorDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // ======================== PhoneNumber ========================
            if (!string.IsNullOrWhiteSpace(DTO.PhoneNumber))
            {
                var phoneNumber = DTO.PhoneNumber.Trim();

                var phoneNumberExists = await _appDbContext.Doctors
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

                var emailExists = await _appDbContext.Doctors
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

            // ======================== Specialties ========================
            var specialtyIds = DTO.DoctorSpecialties
                .Select(x => x.SpecialtyId)
                .ToList();

            var distinctSpecialtyIds = specialtyIds
                .Distinct()
                .ToList();

            if (specialtyIds.Count != distinctSpecialtyIds.Count)
            {
                return Result<bool>.Failure(
                    ResultCodes.DuplicateSpecialty,
                    HttpStatusCodes.BadRequest,
                    "Duplicate specialty IDs found.");
            }

            if (distinctSpecialtyIds.Count > 0)
            {
                var validSpecialtyCount = await _appDbContext.Specialties
                .CountAsync(x => distinctSpecialtyIds.Contains(x.Id));

                if (validSpecialtyCount != distinctSpecialtyIds.Count)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidSpecialty,
                        HttpStatusCodes.BadRequest,
                        "One or more specialty IDs are invalid.");
                }
            }




            return Result<bool>.Success(true);

        }

        private IQueryable<Doctor> ApplyFilters(
            IQueryable<Doctor> query,
            DoctorFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();
                query = query.Where(x =>
                    x.FullName.Contains(search) ||
                    (x.PhoneNumber != null && x.PhoneNumber.Contains(search)) ||
                    (x.Email != null && x.Email.Contains(search))
                    );
            }

            return query;
        }

        private IQueryable<Doctor> ApplySorting(
            IQueryable<Doctor> query,
            DoctorFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<DoctorDTO> ProjectToDTO(
            IQueryable<Doctor> query)
        {
            return query.Select(DoctorExtensions.ToDTOExpression);
        }

        private void UpdateDoctorSpecialties(Doctor Entity, DoctorDTO DTO)
        {
            _appDbContext.DoctorSpecialties
                .RemoveRange(Entity.DoctorSpecialties);

            Entity.DoctorSpecialties.Clear();

            foreach (var specialty in DTO.DoctorSpecialties)
            {
                Entity.DoctorSpecialties.Add(new DoctorSpecialty
                {
                    SpecialtyId = specialty.SpecialtyId
                });
            }
        }

        #endregion

    }
}
