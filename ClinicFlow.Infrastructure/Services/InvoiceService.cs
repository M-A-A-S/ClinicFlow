using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.DTOs.InvoiceItem;
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
    public class InvoiceService : IInvoiceService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<InvoiceService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public InvoiceService(
            IAppDbContext appDbContext,
            ILogger<InvoiceService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(InvoiceDTO dto)
        {
            try
            {
                var validationResult = ValidateInvoiceDTO(dto);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = dto.ToEntity();

                if (string.IsNullOrWhiteSpace(entity.InvoiceNumber))
                {
                    entity.InvoiceNumber = await GenerateInvoiceNumberAsync();
                }

                await AssignReceiptNumbersAsync(entity.Payments);

                entity.RecalculateTotals();

                _appDbContext.Invoices.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(InvoiceService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<InvoiceDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Invoices
                    .AsNoTracking()
                    .Select(InvoiceExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<InvoiceDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(InvoiceService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<InvoiceDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<InvoiceDTO>>> GetAllAsync(InvoiceFilterDTO filter)
        {
            try
            {
                var validationResult = ValidateFilter(filter);

                if (!validationResult.IsSuccess)
                {
                    return Result<PagedResult<InvoiceDTO>>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode,
                        validationResult.Message);
                }

                var query = _appDbContext.Invoices.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<InvoiceDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(InvoiceService),
                   nameof(GetAllAsync));

                return Result<PagedResult<InvoiceDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<InvoiceDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Invoices
                    .AsNoTracking()
                    .Include(x => x.Patient)
                    .Include(x => x.Items)
                    .Include(x => x.Payments)
                        .ThenInclude(x => x.PaymentMethod)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<InvoiceDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<InvoiceDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(InvoiceService),
                   nameof(GetByIdAsync));

                return Result<InvoiceDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, InvoiceDTO dto)
        {
            try
            {
                var validationResult = ValidateInvoiceDTO(dto, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Invoices
                    .Include(x => x.Items)
                    .Include(x => x.Payments)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                var existingItemIds = item.Items.Select(x => x.Id).ToHashSet();

                var invalidIds = (dto.Items ?? new List<InvoiceItemDTO>())
                    .Where(x => x.Id > 0 && !existingItemIds.Contains(x.Id))
                    .Select(x => x.Id)
                    .ToList();

                if (invalidIds.Count > 0)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidData,
                        HttpStatusCodes.BadRequest,
                        $"Item IDs [{string.Join(", ", invalidIds)}] do not belong to invoice {id}.");
                }



                item.UpdateEntity(dto);

                UpdateInvoiceItems(item, dto);

                item.RecalculateTotals();

                await _appDbContext.SaveChangesAsync();

                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(InvoiceService),
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
                var item = await _appDbContext.Invoices
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
                    nameof(InvoiceService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================

        private async Task<string> GenerateInvoiceNumberAsync()
        {
            var now = DateTime.UtcNow;

            var prefix = $"INV-{now:yyyy-MM}-";

            var lastInvoiceNumber = await _appDbContext.Invoices
                .IgnoreQueryFilters()
                .Where(x => x.InvoiceNumber.StartsWith(prefix))
                .OrderByDescending(x => x.InvoiceNumber)
                .Select(x => x.InvoiceNumber)
                .FirstOrDefaultAsync();

            var nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastInvoiceNumber))
            {
                var numberPart = lastInvoiceNumber.Substring(prefix.Length);

                if (int.TryParse(numberPart, out var lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return $"{prefix}{nextNumber:D4}";

        }

        private async Task<string> GenerateReceiptNumberAsync()
        {
            var now = DateTime.UtcNow;
            var prefix = $"RCT-{now:yyyy-MM}-";

            var lastReceiptNumber = await _appDbContext.InvoicePayments
                .AsNoTracking()
                .Where(x =>
                    x.Type == BondType.Receipt &&
                    x.ReceiptNumber != null &&
                    x.ReceiptNumber.StartsWith(prefix))
                .OrderByDescending(x => x.ReceiptNumber)
                .Select(x => x.ReceiptNumber)
                .FirstOrDefaultAsync();

            var nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastReceiptNumber))
            {
                var numberPart = lastReceiptNumber.Substring(prefix.Length);

                if (int.TryParse(numberPart, out var lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return $"{prefix}{nextNumber:D4}";
        }

        private async Task AssignReceiptNumbersAsync(IEnumerable<InvoicePayment> payments)
        {
            var receipts = payments
                .Where(x =>
                    x.Type == BondType.Receipt &&
                    string.IsNullOrWhiteSpace(x.ReceiptNumber))
                .ToList();

            if (receipts.Count == 0)
            {
                return;
            }

            var prefix = $"RCT-{DateTime.UtcNow:yyyy-MM}-";

            var lastReceiptNumber = await _appDbContext.InvoicePayments
                .AsNoTracking()
                .Where(x =>
                    x.Type == BondType.Receipt &&
                    x.ReceiptNumber != null &&
                    x.ReceiptNumber.StartsWith(prefix))
                .OrderByDescending(x => x.ReceiptNumber)
                .Select(x => x.ReceiptNumber)
                .FirstOrDefaultAsync();

            var nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastReceiptNumber))
            {
                var numberPart = lastReceiptNumber.Substring(prefix.Length);

                if (int.TryParse(numberPart, out var lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            foreach (var payment in receipts)
            {
                payment.ReceiptNumber = $"{prefix}{nextNumber:D4}";
                nextNumber++;
            }

        }

        private void UpdateInvoiceItems(Invoice entity, InvoiceDTO dto)
        {
            entity.Items ??= new List<InvoiceItem>();

            var incomingItems = dto.Items ?? new List<InvoiceItemDTO>();

            // IDs of items that actually belong to this invoice
            var existingItemIds = entity.Items
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            // IDs supplied by the client
            var incomingExistingIds = incomingItems
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            //var invalidIds = incomingExistingIds
            //    .Except(existingItemIds)
            //    .ToList();

            //if (invalidIds.Count > 0)
            //{
            //    throw new InvalidOperationException(
            //        $"The following invoice item IDs do not belong to invoice {entity.Id}: " +
            //        $"{string.Join(", ", invalidIds)}");
            //}

            // Remove items that existed before but were not sent anymore
            var itemsToRemove = entity.Items
                .Where(x => x.Id > 0 && !incomingExistingIds.Contains(x.Id))
                .ToList();

            foreach (var removeItem in itemsToRemove)
            {
                entity.Items.Remove(removeItem);
                _appDbContext.InvoiceItems.Remove(removeItem);
            }

            //if (itemsToRemove.Count > 0)
            //{
            //    _appDbContext.InvoiceItems.RemoveRange(itemsToRemove);
            //}

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
                        // Skip items that don't belong to this entity
                        continue;
                    }

                    UpdateInvoiceItem(entityItem, dtoItem);
                }
                // New item
                else
                {
                    var entityItem = new InvoiceItem();
                    UpdateInvoiceItem(entityItem, dtoItem);
                    entity.Items.Add(entityItem);

                }
            }

        }

        private static void UpdateInvoiceItem(
            InvoiceItem entity,
            InvoiceItemDTO dto)
        {
            entity.ItemType = dto.ItemType;
            entity.Description = dto.Description?.Trim();
            entity.Quantity = dto.Quantity;
            entity.UnitPrice = dto.UnitPrice;
            entity.Total = dto.Quantity * dto.UnitPrice;
        }

        private Result<bool> ValidateInvoiceDTO(
            InvoiceDTO dto, int? excludedId = null)
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

            // ========================== Items ==========================
            var items = dto.Items ?? new List<InvoiceItemDTO>();

            if (items.Count == 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvoiceMustHaveItems,
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
                    ResultCodes.InvoiceDuplicateItems,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== Item Validation ==========================
            foreach (var item in items)
            {
                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvoiceInvalidItem,
                        HttpStatusCodes.BadRequest);
                }

                if (item.Quantity <= 0)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvoiceItemQuantityInvalid,
                        HttpStatusCodes.BadRequest);
                }

                if (item.UnitPrice <= 0)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvoiceItemUnitPriceInvalid,
                        HttpStatusCodes.BadRequest);
                }

            }

            return Result<bool>.Success(true);

        }

        private Result<bool> ValidateFilter(InvoiceFilterDTO filter)
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

            if (filter.MinGrandTotal.HasValue &&
                filter.MaxGrandTotal.HasValue &&
                filter.MinGrandTotal.Value > filter.MaxGrandTotal.Value)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidAmountRange,
                    HttpStatusCodes.BadRequest);
            }

            return Result<bool>.Success(true);
        }

        private IQueryable<Invoice> ApplyFilters(
            IQueryable<Invoice> query,
            InvoiceFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                x.InvoiceNumber.Contains(search) ||
                (x.Patient != null &&
                 ((x.Patient.FullName != null && x.Patient.FullName.Contains(search)) ||
                  (x.Patient.PhoneNumber != null && x.Patient.PhoneNumber.Contains(search)))));
            }

            // ========================== Patient ==========================
            if (filter.PatientId.HasValue)
            {
                query = query.Where(x =>
                    x.PatientId == filter.PatientId.Value);
            }

            // ========================== Status ==========================
            if (filter.Status.HasValue)
            {
                query = query.Where(x =>
                    x.Status == filter.Status.Value);
            }

            // ========================== Invoice Date ==========================
            if (filter.FromDate.HasValue)
            {
                var fromDate = filter.FromDate.Value.Date;

                query = query.Where(x =>
                    x.InvoiceDate >= fromDate);
            }

            if (filter.ToDate.HasValue)
            {
                var toDateExclusive =
                    filter.ToDate.Value.Date.AddDays(1);

                query = query.Where(x =>
                    x.InvoiceDate < toDateExclusive);
            }

            // ========================== Grand Total ==========================
            if (filter.MinGrandTotal.HasValue)
            {
                query = query.Where(x =>
                    x.GrandTotal >= filter.MinGrandTotal.Value);
            }

            if (filter.MaxGrandTotal.HasValue)
            {
                query = query.Where(x =>
                    x.GrandTotal <= filter.MaxGrandTotal.Value);
            }



            return query;
        }

        private IQueryable<Invoice> ApplySorting(
            IQueryable<Invoice> query,
            InvoiceFilterDTO filter)
        {
            bool desc = filter.Descending;

            return filter.SortBy switch
            {
                //"PatientId" => desc
                //        ? query.OrderByDescending(x =>
                //            x.Patient != null
                //                ? x.Patient.FullName
                //                : null)
                //        : query.OrderBy(x =>
                //            x.Patient != null
                //                ? x.Patient.FullName
                //                : null),

                "PatientId" => desc 
                    ? query.OrderByDescending(x => x.Patient.FullName)
                    : query.OrderBy(x => x.Patient.FullName),

                _ => query.OrderByProperty(filter.SortBy, desc)
            };

        }

        private IQueryable<InvoiceDTO> ProjectToDTO(
            IQueryable<Invoice> query)
        {
            return query.Select(InvoiceExtensions.ToDTOExpression);
        }

        #endregion

    }
}
