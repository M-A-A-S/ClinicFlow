using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.DTOs.LabOrderItem;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.Entities;
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
    public class LabOrderService : ILabOrderService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<LabOrderService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public LabOrderService(
            IAppDbContext appDbContext,
            ILogger<LabOrderService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(LabOrderDTO DTO)
        {
            try
            {
                var validationResult = ValidateLabOrderDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.LabOrders.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabOrderService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<LabOrderDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.LabOrders
                    .AsNoTracking()
                    .Select(LabOrderExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<LabOrderDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabOrderService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<LabOrderDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<LabOrderDTO>>> GetAllAsync(LabOrderFilterDTO filter)
        {
            try
            {
                var validationResult = ValidateFilter(filter);

                if (!validationResult.IsSuccess)
                {
                    return Result<PagedResult<LabOrderDTO>>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode,
                        validationResult.Message);
                }

                var query = _appDbContext.LabOrders.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<LabOrderDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabOrderService),
                   nameof(GetAllAsync));

                return Result<PagedResult<LabOrderDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<LabOrderDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.LabOrders
                    .AsNoTracking()
                    .Include(x => x.Items)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<LabOrderDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<LabOrderDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabOrderService),
                   nameof(GetByIdAsync));

                return Result<LabOrderDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

       

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, LabOrderDTO DTO)
        {
            try
            {
                var validationResult = ValidateLabOrderDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.LabOrders
                    .Include(x => x.Items)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                UpdateLabOrderItems(item, DTO);

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(LabOrderService),
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
                var item = await _appDbContext.LabOrders
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
                    nameof(LabOrderService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================


        private void UpdateLabOrderItems(LabOrder entity, LabOrderDTO dto)
        {
            entity.Items ??= new List<LabOrderItem>();

            var incomingItems = dto.Items
                ?? new List<LabOrderItemDTO>();

            /// IDs of existing items submitted from the form
            var incomingIds = incomingItems
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            // Remove existing items that were deleted from the form
            var itemsToRemove = entity.Items
                .Where(x => !incomingIds.Contains(x.Id))
                .ToList();

            if (itemsToRemove.Count > 0)
            {
                _appDbContext.LabOrderItems.RemoveRange(itemsToRemove);
            }

            // Add / Update items
            foreach (var dtoItem in incomingItems)
            {
                // Existing item
                if (dtoItem.Id > 0)
                {
                    var entityItem = entity.Items
                        .FirstOrDefault(x => x.Id == dtoItem.Id);

                    if (entityItem == null)
                    {
                        // The submitted item ID does not belong
                        // to this LabOrder.
                        //
                        // Do not attach or update it.
                        continue;
                    }

                    UpdateLabOrderItem(entityItem, dtoItem);  
                }
                // New item
                else
                {
                    var entityItem = new LabOrderItem();
                    UpdateLabOrderItem(entityItem, dtoItem);
                    entity.Items.Add(entityItem);

                }
            }

        }

        private static void UpdateLabOrderItem(
            LabOrderItem entity,
            LabOrderItemDTO dto)
        {
            entity.LabTestId = dto.LabTestId;
            entity.LabOrderId = dto.LabOrderId;
            entity.Status = dto.Status;
        }

        private Result<bool> ValidateLabOrderDTO(
            LabOrderDTO dto, int? excludedId = null)
        {
            // ========================== Required DTO ==========================
            if (dto == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== Patient ==========================
            if (!dto.PatientId.HasValue || dto.PatientId.Value <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PatientRequired,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== Visit ==========================
            if (dto.VisitId.HasValue && dto.VisitId.Value <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidVisit,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== Items ==========================
            var items = dto.Items ?? new List<LabOrderItemDTO>();

            if (items.Count == 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.LabOrderMustHaveItems,
                    HttpStatusCodes.BadRequest);
            }
            // ========================== Duplicate Items ==========================
            var hasDuplicateIds = items
                .Where(x => x != null && x.Id > 0)
                .GroupBy(x => x.Id)
                .Any(g => g.Count() > 1);

            if (hasDuplicateIds)
            {
                return Result<bool>.Failure(
                    ResultCodes.LabOrderDuplicateItems,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== Item Validation ==========================
            foreach (var item in items)
            {
                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.LabOrderInvalidItem,
                        HttpStatusCodes.BadRequest);
                }

                if (item.LabTestId <= 0)
                {
                    return Result<bool>.Failure(
                        ResultCodes.LabTestRequired,
                        HttpStatusCodes.BadRequest);
                }


            }

            return Result<bool>.Success(true);

        }

        private Result<bool> ValidateFilter(LabOrderFilterDTO filter)
        {
            // ========================== Date Range ==========================
            if (filter.FromDate.HasValue &&
                filter.ToDate.HasValue &&
                filter.FromDate.Value > filter.ToDate.Value)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidDateRange,
                    HttpStatusCodes.BadRequest);
            }

            return Result<bool>.Success(true);
        }

        private IQueryable<LabOrder> ApplyFilters(
            IQueryable<LabOrder> query,
            LabOrderFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    (x.Visit != null && x.Visit.VisitNumber.Contains(search)));
            }

            // ========================== Visit ==========================
            if (filter.VisitId.HasValue)
            {
                query = query.Where(x =>
                    x.VisitId == filter.VisitId.Value);
            }

            // ========================== Patient ==========================
            if (filter.PatientId.HasValue)
            {
                query = query.Where(x =>
                    x.PatientId == filter.PatientId.Value);
            }

            // ========================== Order Date ==========================
            if (filter.FromDate.HasValue)
            {
                var fromDate = filter.FromDate.Value.Date;

                query = query.Where(x =>
                    x.OrderDate >= fromDate);
            }

            if (filter.ToDate.HasValue)
            {
                var toDateExclusive =
                    filter.ToDate.Value.Date.AddDays(1);

                query = query.Where(x =>
                    x.OrderDate < toDateExclusive);
            }

            return query;
        }

        private IQueryable<LabOrder> ApplySorting(
            IQueryable<LabOrder> query,
            LabOrderFilterDTO filter)
        {
            bool desc = filter.Descending;

            var currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            var isArabic = currentLanguage.Equals("ar", StringComparison.OrdinalIgnoreCase);

            return filter.SortBy switch
            {

                "VisitId" => desc
                        ? query.OrderByDescending(x => 
                            x.Visit != null
                                ? x.Visit.VisitNumber
                                : null)
                        : query.OrderBy(x =>
                            x.Visit != null
                                ? x.Visit.VisitNumber
                                : null),

                "PatientId" => desc
                        ? query.OrderByDescending(x => 
                            x.Patient != null
                                ? x.Patient.FullName
                                : null)
                        : query.OrderBy(x =>
                            x.Patient != null
                                ? x.Patient.FullName
                                : null),

                _ => query.OrderByProperty(filter.SortBy, desc)
            };

        }

        private IQueryable<LabOrderDTO> ProjectToDTO(
            IQueryable<LabOrder> query)
        {
            return query.Select(LabOrderExtensions.ToDTOExpression);
        }

        #endregion

    }
}
