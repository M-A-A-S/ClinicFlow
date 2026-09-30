using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Bond;
using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class BondService : IBondService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<BondService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public BondService(
            IAppDbContext appDbContext,
            ILogger<BondService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(BondDTO dto)
        {

            try
            {
                var validationResult = await ValidateBondDTO(dto);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = dto.ToEntity();

                entity.BondNumber = await GenerateBondNumberAsync();
                entity.CreatedAt = DateTime.Now;

                _appDbContext.Bonds.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<BondDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Bonds
                    .AsNoTracking()
                    .Select(BondExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<BondDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<BondDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<BondDTO>>> GetAllAsync(BondFilterDTO filter)
        {
            try
            {

                var filterValidation = ValidateFilter(filter);

                if (!filterValidation.IsSuccess)
                {
                    return Result<PagedResult<BondDTO>>.Failure(
                        filterValidation.Code,
                        filterValidation.StatusCode);
                }

                var query = _appDbContext.Bonds.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<BondDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondService),
                   nameof(GetAllAsync));

                return Result<PagedResult<BondDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<BondDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Bonds
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Select(BondExtensions.ToDTOExpression)
                    .FirstOrDefaultAsync();

                if (item == null)
                {
                    return Result<BondDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<BondDTO>.Success(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(BondService),
                   nameof(GetByIdAsync));

                return Result<BondDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }
        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, BondDTO dto)
        {
            try
            {
                var validationResult = await ValidateBondDTO(dto, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Bonds
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(dto);

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(BondService),
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
                var item = await _appDbContext.Bonds
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
                    nameof(BondService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================

        private async Task<string> GenerateBondNumberAsync()
        {
            var now = DateTime.UtcNow;
            var prefix = $"BOD-{now:yyyy-MM}-";

            var existingNumbers = await _appDbContext.Bonds
                .IgnoreQueryFilters()
                .Where(x => x.BondNumber.StartsWith(prefix))
                .Select(x => x.BondNumber)
                .ToListAsync();

            var nextNumber = 1;

            if (existingNumbers.Count > 0)
            {
                var maxNumber = existingNumbers
                    .Select(num => num.Substring(prefix.Length))
                    .Select(numStr => int.TryParse(numStr, out var parsed) ? parsed : 0)
                    .Max();

                nextNumber = maxNumber + 1;
            }

            return $"{prefix}{nextNumber:D5}";
        }

        private async Task<Result<bool>> ValidateBondDTO(BondDTO dto, int? excludedId = null)
        {
            if (dto == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            if (dto.Amount <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.AmountInvalid,
                    HttpStatusCodes.BadRequest);
            }

            if (dto.PaymentMethodId <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PaymentMethodRequired,
                    HttpStatusCodes.BadRequest);
            }

            var paymentMethod = await _appDbContext.PaymentMethods
                .AnyAsync(x => x.Id == dto.PaymentMethodId);

            if (!paymentMethod)
            {
                return Result<bool>.Failure(
                    ResultCodes.PaymentMethodNotFound,
                    HttpStatusCodes.BadRequest);
            }

            var category = await _appDbContext.BondCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.CategoryId);

            if (category == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.CategoryNotFound,
                    HttpStatusCodes.BadRequest);
            }

            if (dto.Type != category.Type)
            {
                return Result<bool>.Failure(
                    ResultCodes.CategoryMismatch,
                    HttpStatusCodes.BadRequest);
            }

            var partyValidation = await ValidatePartyAsync(dto.Party, dto.PartyId);

            if (!partyValidation.IsSuccess)
            {
                return partyValidation;
            }

            return Result<bool>.Success(true);

        }


        private async Task<Result<bool>> ValidatePartyAsync(PartyType partyType, int? partyId)
        {
            if (partyType == PartyType.General)
            {
                return Result<bool>.Success(true);
            }

            if (!partyId.HasValue ||  partyId.Value <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.PartyIdRequired,
                    HttpStatusCodes.BadRequest);
            }

            bool exists = partyType switch
            {
                PartyType.Patient => await _appDbContext.Patients.AnyAsync(x => x.Id == partyId.Value),
                PartyType.Doctor => await _appDbContext.Doctors.AnyAsync(x => x.Id == partyId.Value),
                _ => false
            };

            if (!exists)
            {
                return Result<bool>.Failure(
                    ResultCodes.PartyNotFound,
                    HttpStatusCodes.BadRequest);
            }

            return Result<bool>.Success(true);

        }

        private Result<bool> ValidateFilter(BondFilterDTO filter)
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

            if (filter.MinAmount.HasValue &&
                filter.MaxAmount.HasValue &&
                filter.MinAmount.Value > filter.MaxAmount.Value)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidAmountRange,
                    HttpStatusCodes.BadRequest);
            }

            return Result<bool>.Success(true);
        }

        private IQueryable<Bond> ApplyFilters(
            IQueryable<Bond> query,
            BondFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    x.BondNumber.Contains(search) ||
                    (x.Notes != null && x.Notes.Contains(search)) ||
                    (x.ReferenceNumber != null && x.ReferenceNumber.Contains(search)) ||
                    (x.Category.NameEn != null && x.Category.NameEn.Contains(search)) ||
                    (x.Category.NameAr != null && x.Category.NameAr.Contains(search)) ||
                    (x.PaymentMethod.NameEn != null && x.PaymentMethod.NameEn.Contains(search)) ||
                    (x.PaymentMethod.NameAr != null && x.PaymentMethod.NameAr.Contains(search))
                    );

            }

            // ========================== Type ==========================
            if (filter.Type.HasValue)
            {
                query = query.Where(x => x.Type == filter.Type.Value);
            }

            // ========================== Party ==========================
            if (filter.Party.HasValue)
            {
                query = query.Where(x => x.Party == filter.Party.Value);
            }

            // ========================== PartyId ==========================
            if (filter.PartyId.HasValue)
            {
                query = query.Where(x => x.PartyId == filter.PartyId.Value);
            }

            // ========================== Category ==========================
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId.Value);
            }

            // ========================== PaymentMethod ==========================
            if (filter.PaymentMethodId.HasValue)
            {
                query = query.Where(x => x.PaymentMethodId == filter.PaymentMethodId.Value);
            }

            // ========================== FromDate ==========================
            if (filter.FromDate.HasValue)
            {
                query = query.Where(x =>
                    x.IssueDate >= filter.FromDate.Value);
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
                    x.IssueDate < toDateInclusive);
            }

            // ========================== MinAmount ==========================
            if (filter.MinAmount.HasValue)
            {
                query = query.Where(x => x.Amount >= filter.MinAmount.Value);
            }

            // ========================== MaxAmount ==========================
            if (filter.MaxAmount.HasValue)
            {
                query = query.Where(x => x.Amount <= filter.MaxAmount.Value);
            }

            return query;
        }

        private IQueryable<Bond> ApplySorting(
            IQueryable<Bond> query,
            BondFilterDTO filter)
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

                "PaymentMethodId" => isArabic
                    ? (desc
                        ? query.OrderByDescending(x => x.PaymentMethod.NameAr)
                        : query.OrderBy(x => x.PaymentMethod.NameAr)
                    ) :
                    (desc
                        ? query.OrderByDescending(x => x.PaymentMethod.NameEn)
                        : query.OrderBy(x => x.PaymentMethod.NameEn)
                    ),

                _ => query.OrderByProperty(filter.SortBy, desc)
            };
        }

        private IQueryable<BondDTO> ProjectToDTO(
            IQueryable<Bond> query)
        {
            return query.Select(BondExtensions.ToDTOExpression);
        }

        #endregion

    }
}
