using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.LabTestParameter;
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
    public class LabTestService : ILabTestService
    {

        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<LabTestService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public LabTestService(
            IAppDbContext appDbContext,
            ILogger<LabTestService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(LabTestDTO DTO)
        {
            try
            {
                var validationResult = await ValidateLabTestDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.LabTests.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabTestService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<LabTestDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.LabTests
                    .AsNoTracking()
                    .Select(LabTestExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<LabTestDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabTestService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<LabTestDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<LabTestDTO>>> GetAllAsync(LabTestFilterDTO filter)
        {
            try
            {
                var validationResult = ValidateFilter(filter);

                if (!validationResult.IsSuccess)
                {
                    return Result<PagedResult<LabTestDTO>>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode,
                        validationResult.Message);
                }

                var query = _appDbContext.LabTests.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<LabTestDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabTestService),
                   nameof(GetAllAsync));

                return Result<PagedResult<LabTestDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<LabTestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.LabTests
                    .AsNoTracking()
                    .Include(x => x.Category)
                    .Include(x => x.Parameters)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<LabTestDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<LabTestDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabTestService),
                   nameof(GetByIdAsync));

                return Result<LabTestDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<LabTestSearchDTO>>> GetForSelectAsync()
        {
            try
            {
                var query = _appDbContext.LabTests
                .AsNoTracking();

                var items = await query
                    .Take(20)
                    .Select(x => new LabTestSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<LabTestSearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<LabTestSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, LabTestDTO DTO)
        {
            try
            {
                var validationResult = await ValidateLabTestDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.LabTests
                    .Include(x => x.Category)
                    .Include(x => x.Parameters)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                UpdateLabTestParameters(item, DTO);

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(LabTestService),
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
                var item = await _appDbContext.LabTests
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
                    nameof(LabTestService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================


        private void UpdateLabTestParameters(LabTest entity, LabTestDTO dto)
        {
            entity.Parameters ??= new List<LabTestParameter>();

            var incomingParameters = dto.Parameters
                ?? new List<LabTestParameterDTO>();

            // IDs of existing parameters submitted from the form
            var incomingIds = incomingParameters
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            // Remove existing parameters that were deleted from the form
            var parametersToRemove = entity.Parameters
                .Where(x => !incomingIds.Contains(x.Id))
                .ToList();

            if (parametersToRemove.Count > 0)
            {
                _appDbContext.LabTestParameters.RemoveRange(parametersToRemove);
            }

            // Add / Update parameters
            for (int i = 0; i < incomingParameters.Count; i++)
            {
                var dtoParameter = incomingParameters[i];

                // DisplayOrder is controlled by the server
                var displayOrder = i + 1;

                // Existing parameter
                if (dtoParameter.Id > 0)
                {
                    var entityParameter = entity.Parameters
                        .FirstOrDefault(x => x.Id == dtoParameter.Id);

                    if (entityParameter == null)
                    {
                        // Parameter ID does not belong to this LabTest.
                        // Do not update/attach it.
                        continue;
                    }

                    entityParameter.NameEn = dtoParameter.NameEn;
                    entityParameter.NameAr = dtoParameter.NameAr;
                    entityParameter.Unit = dtoParameter.Unit;
                    entityParameter.NormalRange = dtoParameter.NormalRange;
                    entityParameter.IsActive = dtoParameter.IsActive;
                    entityParameter.DisplayOrder = displayOrder;
                }
                // New parameter
                else
                {
                    var entityParameter = new LabTestParameter
                    {
                        NameEn = dtoParameter.NameEn,
                        NameAr = dtoParameter.NameAr,
                        Unit = dtoParameter.Unit,
                        NormalRange = dtoParameter.NormalRange,
                        IsActive = dtoParameter.IsActive,
                        DisplayOrder = displayOrder,
                    };

                    entity.Parameters.Add(entityParameter);
                }
            }


        }

        private async Task<Result<bool>> ValidateLabTestDTO(LabTestDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // ======================== NameEn ========================
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

            // ======================== NameAr ========================
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

        private Result<bool> ValidateFilter(LabTestFilterDTO filter)
        {
            // ========================== Price ==========================
            if (filter.MinPrice.HasValue &&
                filter.MaxPrice.HasValue &&
                filter.MinPrice.Value > filter.MaxPrice.Value)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidPriceRange,
                    HttpStatusCodes.BadRequest);
            }

            return Result<bool>.Success(true);
        }

        private IQueryable<LabTest> ApplyFilters(
            IQueryable<LabTest> query,
            LabTestFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    x.NameEn.Contains(search) ||
                    (x.NameAr != null && x.NameAr.Contains(search)) ||
                    (x.Category != null && x.Category.NameEn.Contains(search)) ||
                    (x.Category != null && 
                        x.Category.NameAr != null && 
                        x.Category.NameAr.Contains(search))
                    );
            }

            // ========================== Category ==========================
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(x =>
                    x.CategoryId == filter.CategoryId.Value);
            }

            // ========================== IsActive ==========================
            if (filter.IsActive.HasValue)
            {
                query = query.Where(x =>
                    x.IsActive == filter.IsActive.Value);
            }

            // ========================== Price ==========================
            if (filter.MinPrice.HasValue)
            {
                query = query.Where(x =>
                    x.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(x =>
                    x.Price <= filter.MaxPrice.Value);
            }

            return query;
        }

        private IQueryable<LabTest> ApplySorting(
            IQueryable<LabTest> query,
            LabTestFilterDTO filter)
        {
            bool desc = filter.Descending;

            var currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            var isArabic = currentLanguage.Equals("ar", StringComparison.OrdinalIgnoreCase);

            return filter.SortBy switch
            {
                "CategoryId" => isArabic
                    ? (desc
                        ? query.OrderByDescending(x => x.Category.NameAr)
                        : query.OrderBy(x => x.Category.NameAr)
                    ) :
                    (desc
                        ? query.OrderByDescending(x => x.Category.NameEn)
                        : query.OrderBy(x => x.Category.NameEn)
                    ),

                _ => query.OrderByProperty(filter.SortBy, desc)
            };

        }

        private IQueryable<LabTestDTO> ProjectToDTO(
            IQueryable<LabTest> query)
        {
            return query.Select(LabTestExtensions.ToDTOExpression);
        }

        #endregion

    }
}
