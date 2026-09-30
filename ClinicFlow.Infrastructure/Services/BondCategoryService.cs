using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.BondCategory;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class BondCategoryService : IBondCategoryService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<BondCategoryService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public BondCategoryService(
            IAppDbContext appDbContext,
            ILogger<BondCategoryService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(BondCategoryDTO dto)
        {

            try
            {
                var validationResult = await ValidateBondCategoryDTO(dto);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = dto.ToEntity();

                _appDbContext.BondCategories.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondCategoryService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<BondCategoryDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.BondCategories
                    .AsNoTracking()
                    .Select(BondCategoryExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<BondCategoryDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondCategoryService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<BondCategoryDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<BondCategoryDTO>>> GetAllAsync(BondCategoryFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.BondCategories.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<BondCategoryDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondCategoryService),
                   nameof(GetAllAsync));

                return Result<PagedResult<BondCategoryDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<BondCategoryDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.BondCategories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<BondCategoryDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<BondCategoryDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondCategoryService),
                   nameof(GetByIdAsync));

                return Result<BondCategoryDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<BondCategorySearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.BondCategories
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
                    .Select(x => new BondCategorySearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<BondCategorySearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(BondCategoryService), nameof(SearchAsync));
                return Result<IEnumerable<BondCategorySearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }

        public async Task<Result<IEnumerable<BondCategorySearchDTO>>> GetForSelectAsync()
        {
            try
            {

                var items = await _appDbContext.BondCategories
                    .AsNoTracking()
                    .OrderBy(x => x.NameEn)
                    .Select(x => new BondCategorySearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();


                return Result<IEnumerable<BondCategorySearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<BondCategorySearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, BondCategoryDTO DTO)
        {
            try
            {
                var validationResult = await ValidateBondCategoryDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.BondCategories
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
                    nameof(BondCategoryService),
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
                var item = await _appDbContext.BondCategories
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
                    nameof(BondCategoryService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateBondCategoryDTO(BondCategoryDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            bool nameEnExists =
                await _appDbContext.BondCategories
                .AnyAsync(x => x.NameEn.ToLower() == DTO.NameEn.ToLower() &&
                (excludedId == null || x.Id != excludedId));

            if (nameEnExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameEnExists,
                    HttpStatusCodes.Conflict);
            }

            bool nameArExists =
                await _appDbContext.BondCategories
                .AnyAsync(x => x.NameAr == DTO.NameAr && (excludedId == null || x.Id != excludedId));

            if (nameArExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameArExists,
                    HttpStatusCodes.Conflict);
            }

            return Result<bool>.Success(true);

        }

        private IQueryable<BondCategory> ApplyFilters(
            IQueryable<BondCategory> query,
            BondCategoryFilterDTO filter)
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

        private IQueryable<BondCategory> ApplySorting(
            IQueryable<BondCategory> query,
            BondCategoryFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<BondCategoryDTO> ProjectToDTO(
            IQueryable<BondCategory> query)
        {
            return query.Select(BondCategoryExtensions.ToDTOExpression);
        }

        #endregion

    }
}
