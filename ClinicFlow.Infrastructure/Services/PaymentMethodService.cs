using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.PaymentMethod;
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
    public class PaymentMethodService : IPaymentMethodService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<PaymentMethodService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public PaymentMethodService(
            IAppDbContext appDbContext,
            ILogger<PaymentMethodService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(PaymentMethodDTO dto)
        {

            try
            {
                var validationResult = await ValidatePaymentMethodDTO(dto);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = dto.ToEntity();

                _appDbContext.PaymentMethods.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PaymentMethodService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<PaymentMethodDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.PaymentMethods
                    .AsNoTracking()
                    .Select(PaymentMethodExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<PaymentMethodDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PaymentMethodService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<PaymentMethodDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<PaymentMethodDTO>>> GetAllAsync(PaymentMethodFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.PaymentMethods.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<PaymentMethodDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PaymentMethodService),
                   nameof(GetAllAsync));

                return Result<PagedResult<PaymentMethodDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PaymentMethodDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.PaymentMethods
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<PaymentMethodDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<PaymentMethodDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(PaymentMethodService),
                   nameof(GetByIdAsync));

                return Result<PaymentMethodDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<PaymentMethodSearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.PaymentMethods
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
                    .Select(x => new PaymentMethodSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<PaymentMethodSearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(PaymentMethodService), nameof(SearchAsync));
                return Result<IEnumerable<PaymentMethodSearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }

        public async Task<Result<IEnumerable<PaymentMethodSearchDTO>>> GetForSelectAsync()
        {
            try
            {

                var items = await _appDbContext.PaymentMethods
                    .AsNoTracking()
                    .OrderBy(x => x.NameEn)
                    .Select(x => new PaymentMethodSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<PaymentMethodSearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<PaymentMethodSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, PaymentMethodDTO dto)
        {
            try
            {
                var validationResult = await ValidatePaymentMethodDTO(dto, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.PaymentMethods
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdatEentity(dto);

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(PaymentMethodService),
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
                var item = await _appDbContext.PaymentMethods
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
                    nameof(PaymentMethodService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidatePaymentMethodDTO(PaymentMethodDTO dto, int? excludedId = null)
        {
            if (dto == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            bool nameEnExists =
                await _appDbContext.PaymentMethods
                .AnyAsync(x => x.NameEn.ToLower() == dto.NameEn.ToLower() &&
                (excludedId == null || x.Id != excludedId));

            if (nameEnExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameEnExists,
                    HttpStatusCodes.Conflict);
            }

            bool nameArExists =
                await _appDbContext.PaymentMethods
                .AnyAsync(x => x.NameAr == dto.NameAr && (excludedId == null || x.Id != excludedId));

            if (nameArExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameArExists,
                    HttpStatusCodes.Conflict);
            }

            return Result<bool>.Success(true);

        }

        private IQueryable<PaymentMethod> ApplyFilters(
            IQueryable<PaymentMethod> query,
            PaymentMethodFilterDTO filter)
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

        private IQueryable<PaymentMethod> ApplySorting(
            IQueryable<PaymentMethod> query,
            PaymentMethodFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<PaymentMethodDTO> ProjectToDTO(
            IQueryable<PaymentMethod> query)
        {
            return query.Select(PaymentMethodExtensions.ToDTOExpression);
        }

        #endregion

    }
}
