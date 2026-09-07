using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Clinic;
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
    public class ClinicService : IClinicService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<ClinicService> _logger;
        private readonly IMemoryCache _cache;

        #endregion

        #region ========================= Constructors =========================
        public ClinicService(
            IAppDbContext appDbContext,
            ILogger<ClinicService> logger,
            IMemoryCache cache)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _cache = cache;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(ClinicDTO DTO)
        {
            try
            {
                var validationResult = await ValidateClinicDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.Clinics.Add(entity);
                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.ClinicSelect);
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ClinicService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<ClinicDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Clinics
                    .AsNoTracking()
                    .Select(ClinicExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<ClinicDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ClinicService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<ClinicDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<ClinicDTO>>> GetAllAsync(ClinicFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.Clinics.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<ClinicDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ClinicService),
                   nameof(GetAllAsync));

                return Result<PagedResult<ClinicDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<ClinicDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Clinics
                    .AsNoTracking()
                    .Include(x => x.ClinicDoctors)
                        .ThenInclude(x => x.Doctor)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<ClinicDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<ClinicDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ClinicService),
                   nameof(GetByIdAsync));

                return Result<ClinicDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<ClinicSearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.Clinics
                .AsNoTracking();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var term = search.Trim();
                    query = query.Where(x =>
                        x.NameEn.Contains(term) ||
                        x.NameAr.Contains(term) ||
                        (x.DescriptionEn != null && x.DescriptionEn.Contains(term)) ||
                        (x.DescriptionAr != null && x.DescriptionAr.Contains(term))
                       );
                }

                var items = await query
                    .Take(20)
                    .Select(x => new ClinicSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr
                    })
                    .ToListAsync();

                return Result<IEnumerable<ClinicSearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(ClinicService), nameof(SearchAsync));
                return Result<IEnumerable<ClinicSearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }

        public async Task<Result<IEnumerable<ClinicSearchDTO>>> GetForSelectAsync()
        {
            try
            {
                if (_cache.TryGetValue(
                    CacheKeys.ClinicSelect,
                    out IEnumerable<ClinicSearchDTO>? items))
                {
                    return Result<IEnumerable<ClinicSearchDTO>>
                        .Success(items);
                }


                items = await _appDbContext.Clinics
                    .AsNoTracking()
                    .OrderBy(x => x.NameEn)
                    .Select(x => new ClinicSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr
                    })
                    .ToListAsync();


                _cache.Set(
                    CacheKeys.ClinicSelect,
                    items,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
                    });


                return Result<IEnumerable<ClinicSearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<ClinicSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, ClinicDTO DTO)
        {
            try
            {
                var validationResult = await ValidateClinicDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Clinics
                    .Include(x => x.ClinicDoctors)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                UpdateClinicDoctors(item, DTO);

                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.ClinicSelect);
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(ClinicService),
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
                var item = await _appDbContext.Clinics
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
                _cache.Remove(CacheKeys.ClinicSelect);
                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(ClinicService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateClinicDTO(ClinicDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // ======================== NameEn ========================
            bool nameEnExists =
                await _appDbContext.Clinics
                .AnyAsync(x => x.NameEn.ToLower() == DTO.NameEn.ToLower() &&
                (excludedId == null || x.Id != excludedId));

            if (nameEnExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameEnExists,
                    HttpStatusCodes.Conflict);
            }

            // ======================== NameAr ========================
            bool nameArExists =
                await _appDbContext.Clinics
                .AnyAsync(x => x.NameAr == DTO.NameAr && (excludedId == null || x.Id != excludedId));

            if (nameArExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameArExists,
                    HttpStatusCodes.Conflict);
            }

            // ======================== ClinicDoctors ========================
            var clinicDoctorIds = DTO.ClinicDoctors
                .Select(x => x.DoctorId)
                .ToList();

            var distinctClinicDoctorIds = clinicDoctorIds
                .Distinct()
                .ToList();

            if (clinicDoctorIds.Count != distinctClinicDoctorIds.Count)
            {
                return Result<bool>.Failure(
                    ResultCodes.DuplicateClinicDoctor,
                    HttpStatusCodes.BadRequest,
                    "Duplicate clinic doctor IDs found.");
            }

            if (distinctClinicDoctorIds.Count > 0)
            {
                var validClinicDoctorCount = await _appDbContext.ClinicDoctors
                    .CountAsync(x => distinctClinicDoctorIds.Contains(x.Id));

                if (validClinicDoctorCount != distinctClinicDoctorIds.Count)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidClinicDoctor,
                        HttpStatusCodes.BadRequest,
                        "One or more clinic doctor IDs are invalid.");
                }
            }




            return Result<bool>.Success(true);

        }

        private IQueryable<Clinic> ApplyFilters(
            IQueryable<Clinic> query,
            ClinicFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();
                query = query.Where(x =>
                    x.NameEn.Contains(search) ||
                    x.NameAr.Contains(search) ||
                    (x.DescriptionEn != null && x.DescriptionEn.Contains(search)) ||
                    (x.DescriptionAr != null && x.DescriptionAr.Contains(search))
                    );
            }

            return query;
        }

        private IQueryable<Clinic> ApplySorting(
            IQueryable<Clinic> query,
            ClinicFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<ClinicDTO> ProjectToDTO(
            IQueryable<Clinic> query)
        {
            return query.Select(ClinicExtensions.ToDTOExpression);
        }

        private void UpdateClinicDoctors(Clinic Entity, ClinicDTO DTO)
        {
            _appDbContext.ClinicDoctors
                .RemoveRange(Entity.ClinicDoctors);

            Entity.ClinicDoctors.Clear();

            foreach (var doctor in DTO.ClinicDoctors)
            {
                Entity.ClinicDoctors.Add(new ClinicDoctor
                {
                    DoctorId = doctor.DoctorId
                });
            }
        }

        #endregion

    }
}
