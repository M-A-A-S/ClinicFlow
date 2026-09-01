using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.ChronicCondition;
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
    public class ChronicConditionService : IChronicConditionService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<ChronicConditionService> _logger;
        private readonly IMemoryCache _cache;

        #endregion

        #region ========================= Constructors =========================
        public ChronicConditionService(
            IAppDbContext appDbContext,
            ILogger<ChronicConditionService> logger,
            IMemoryCache cache)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _cache = cache;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(ChronicConditionDTO DTO)
        {

            try
            {
                var validationResult = await ValidateChronicConditionDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.ChronicConditions.Add(entity);
                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.ChronicConditionSelect);
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ChronicConditionService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<ChronicConditionDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.ChronicConditions
                    .AsNoTracking()
                    .Select(ChronicConditionExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<ChronicConditionDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ChronicConditionService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<ChronicConditionDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<ChronicConditionDTO>>> GetAllAsync(ChronicConditionFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.ChronicConditions.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<ChronicConditionDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ChronicConditionService),
                   nameof(GetAllAsync));

                return Result<PagedResult<ChronicConditionDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<ChronicConditionDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.ChronicConditions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<ChronicConditionDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<ChronicConditionDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(ChronicConditionService),
                   nameof(GetByIdAsync));

                return Result<ChronicConditionDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<ChronicConditionSearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.ChronicConditions
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
                    .Select(x => new ChronicConditionSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<ChronicConditionSearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(ChronicConditionService), nameof(SearchAsync));
                return Result<IEnumerable<ChronicConditionSearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }

        public async Task<Result<IEnumerable<ChronicConditionSearchDTO>>> GetForSelectAsync()
        {
            try
            {
                if (_cache.TryGetValue(
                    CacheKeys.ChronicConditionSelect,
                    out IEnumerable<ChronicConditionSearchDTO>? items))
                {
                    return Result<IEnumerable<ChronicConditionSearchDTO>>
                        .Success(items);
                }


                items = await _appDbContext.ChronicConditions
                    .AsNoTracking()
                    .OrderBy(x => x.NameEn)
                    .Select(x => new ChronicConditionSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();


                _cache.Set(
                    CacheKeys.ChronicConditionSelect,
                    items,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
                    });


                return Result<IEnumerable<ChronicConditionSearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<ChronicConditionSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, ChronicConditionDTO DTO)
        {
            try
            {
                var validationResult = await ValidateChronicConditionDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.ChronicConditions
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                await _appDbContext.SaveChangesAsync();
                _cache.Remove(CacheKeys.ChronicConditionSelect);
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(ChronicConditionService),
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
                var item = await _appDbContext.ChronicConditions
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
                _cache.Remove(CacheKeys.ChronicConditionSelect);
                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(ChronicConditionService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateChronicConditionDTO(ChronicConditionDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            bool nameEnExists =
                await _appDbContext.ChronicConditions
                .AnyAsync(x => x.NameEn.ToLower() == DTO.NameEn.ToLower() &&
                (excludedId == null || x.Id != excludedId));

            if (nameEnExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameEnExists,
                    HttpStatusCodes.Conflict);
            }

            bool nameArExists =
                await _appDbContext.ChronicConditions
                .AnyAsync(x => x.NameAr == DTO.NameAr && (excludedId == null || x.Id != excludedId));

            if (nameArExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameArExists,
                    HttpStatusCodes.Conflict);
            }

            return Result<bool>.Success(true);

        }

        private IQueryable<ChronicCondition> ApplyFilters(
            IQueryable<ChronicCondition> query,
            ChronicConditionFilterDTO filter)
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

        private IQueryable<ChronicCondition> ApplySorting(
            IQueryable<ChronicCondition> query,
            ChronicConditionFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<ChronicConditionDTO> ProjectToDTO(
            IQueryable<ChronicCondition> query)
        {
            return query.Select(ChronicConditionExtensions.ToDTOExpression);
        }

        #endregion

    }
}
