using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using ClinicFlow.Infrastructure.Extensions;
using ClinicFlow.Domain.Entities;

namespace ClinicFlow.Infrastructure.Services
{
    public class AllergyService : IAllergyService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<AllergyService> _logger;
        private readonly IMemoryCache _cache;

        #endregion

        #region ========================= Constructors =========================
        public AllergyService(
            IAppDbContext appDbContext,
            ILogger<AllergyService> logger,
            IMemoryCache cache)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _cache = cache;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(AllergyDTO DTO)
        {

            try
            {
                var validationResult = await ValidateAllergyDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.Allergies.Add(entity);
                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.AllergySelect);
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AllergyService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<AllergyDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Allergies
                    .AsNoTracking()
                    .Select(AllergyExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<AllergyDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AllergyService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<AllergyDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<AllergyDTO>>> GetAllAsync(AllergyFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.Allergies.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<AllergyDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AllergyService),
                   nameof(GetAllAsync));

                return Result<PagedResult<AllergyDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<AllergyDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Allergies
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<AllergyDTO>.Failure(
                        ResultCodes.NotFound, 
                        HttpStatusCodes.NotFound);
                }
                return Result<AllergyDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(AllergyService),
                   nameof(GetByIdAsync));

                return Result<AllergyDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<AllergySearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.Allergies
                .AsNoTracking();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var term = search.Trim();
                    query = query.Where(x =>
                        x.NameEn.Contains(term) ||
                        x.NameAr.Contains(term));
                }

                var items = await query
                    .Take(20)
                    .Select(x => new AllergySearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<AllergySearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(AllergyService), nameof(SearchAsync));
                return Result<IEnumerable<AllergySearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
            
        }

        public async Task<Result<IEnumerable<AllergySearchDTO>>> GetForSelectAsync()
        {
            try
            {
                if (_cache.TryGetValue(
                    CacheKeys.AllergySelect,
                    out IEnumerable<AllergySearchDTO>? items))
                {
                    return Result<IEnumerable<AllergySearchDTO>>
                        .Success(items);
                }


                items = await _appDbContext.Allergies
                    .AsNoTracking()
                    .OrderBy(x => x.NameEn)
                    .Select(x => new AllergySearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();


                _cache.Set(
                    CacheKeys.AllergySelect,
                    items,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
                    });


                return Result<IEnumerable<AllergySearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<AllergySearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, AllergyDTO DTO)
        {

            try
            {
                var validationResult = await ValidateAllergyDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Allergies
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound, 
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.AllergySelect);
                return Result<bool>.Success(true, 
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(AllergyService),
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
                var item = await _appDbContext.Allergies
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
                _cache.Remove(CacheKeys.AllergySelect);
                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(AllergyService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateAllergyDTO(AllergyDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            bool nameEnExists =
                await _appDbContext.Allergies
                .AnyAsync(x => x.NameEn.ToLower() == DTO.NameEn.ToLower() && 
                (excludedId == null || x.Id != excludedId));

            if (nameEnExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameEnExists,
                    HttpStatusCodes.Conflict);
            }

            bool nameArExists =
                await _appDbContext.Allergies
                .AnyAsync(x => x.NameAr == DTO.NameAr && (excludedId == null || x.Id != excludedId));

            if (nameArExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameArExists,
                    HttpStatusCodes.Conflict);
            }

            return Result<bool>.Success(true);

        }

        private IQueryable<Allergy> ApplyFilters(
            IQueryable<Allergy> query,
            AllergyFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();
                query = query.Where(x =>
                    x.NameEn.Contains(search) ||
                    x.NameAr.Contains(search));
            }
            return query;
        }

        private IQueryable<Allergy> ApplySorting(
            IQueryable<Allergy> query,
            AllergyFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<AllergyDTO> ProjectToDTO(
            IQueryable<Allergy> query)
        {
            return query.Select(AllergyExtensions.ToDTOExpression);
        }

        #endregion

    }
}
